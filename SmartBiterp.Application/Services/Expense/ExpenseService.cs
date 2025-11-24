using AutoMapper;

using SmartBiterp.Application.DTOs.Expense;
using SmartBiterp.Application.Interfaces.Expense;
using SmartBiterp.Domain.Entities.Expense;
using SmartBiterp.Domain.Interfaces;
using SmartBiterp.Shared.Common.Responses;

namespace SmartBiterp.Application.Services.Expense
{
    public class ExpenseService : IExpenseService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ExpenseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ApiResponse<object>> CreateAsync(CreateExpenseHeaderRequest request)
        {
            if (request.Details == null || !request.Details.Any())
                return ApiResponse<object>.Fail("At least one expense detail must be provided.");

            using var trx = await _uow.BeginTransactionAsync();

            try
            {
                var header = new ExpenseHeader
                {
                    Date = request.Date,
                    MoneyFundId = request.MoneyFundId,
                    StoreName = request.StoreName,
                    DocumentType = request.DocumentType,
                    Notes = request.Observations
                };

                await _uow.Expenses.AddHeaderAsync(header);

                var exceeded = new List<object>();

                foreach (var det in request.Details)
                {
                    var budget = await _uow.Budgets.GetByMonthAndTypeAsync(
                        request.Date.Year,
                        request.Date.Month,
                        det.ExpenseTypeId
                    );

                    if (budget == null)
                    {
                        await trx.RollbackAsync();
                        return ApiResponse<object>.Fail(
                            $"No budget exists for expense type {det.ExpenseTypeId} in {request.Date.Month}/{request.Date.Year}."
                        );
                    }

                    decimal spent = await _uow.Expenses.GetTotalSpentAsync(
                        request.Date.Year,
                        request.Date.Month,
                        det.ExpenseTypeId
                    );

                    decimal newTotal = spent + det.Amount;

                    if (newTotal > budget.AllocatedAmount)
                    {
                        exceeded.Add(new
                        {
                            ExpenseTypeId = det.ExpenseTypeId,
                            Budget = budget.AllocatedAmount,
                            Spent = spent,
                            NewExpense = det.Amount,
                            Total = newTotal
                        });
                    }

                    await _uow.Expenses.AddDetailAsync(new ExpenseDetail
                    {
                        ExpenseHeader = header,
                        ExpenseTypeId = det.ExpenseTypeId,
                        Amount = det.Amount
                    });
                }

                if (exceeded.Any())
                {
                    await trx.RollbackAsync();
                    return ApiResponse<object>.Fail("Budget exceeded.", exceeded);
                }

                await _uow.SaveChangesAsync();
                await trx.CommitAsync();

                return ApiResponse<object>.Ok(new { id = header.Id }, "Expense successfully recorded.");
            }
            catch (Exception ex)
            {
                await trx.RollbackAsync();
                return ApiResponse<object>.Fail($"Error while recording expense: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<ExpenseHeaderDto>>> GetAllAsync()
        {
            var result = await _uow.Expenses.GetExpensesByDateRangeAsync(
                DateTime.MinValue,
                DateTime.MaxValue
            );

            var mapped = _mapper.Map<IEnumerable<ExpenseHeaderDto>>(result);
            return ApiResponse<IEnumerable<ExpenseHeaderDto>>.Ok(mapped);
        }

        public async Task<ApiResponse<ExpenseHeaderDto?>> GetByIdAsync(int id)
        {
            var entity = await _uow.Expenses.GetByIdAsync(id);

            if (entity == null)
                return ApiResponse<ExpenseHeaderDto?>.Fail("Expense not found.");

            var mapped = _mapper.Map<ExpenseHeaderDto>(entity);
            return ApiResponse<ExpenseHeaderDto?>.Ok(mapped);
        }

        public async Task<ApiResponse<string>> DeleteAsync(int id)
        {
            var header = await _uow.Expenses.GetByIdAsync(id);

            if (header == null)
                return ApiResponse<string>.Fail("Expense not found.");

            _uow.Expenses.RemoveHeader(header);

            await _uow.SaveChangesAsync();

            return ApiResponse<string>.Ok("Expense successfully deleted.");
        }
    }
}