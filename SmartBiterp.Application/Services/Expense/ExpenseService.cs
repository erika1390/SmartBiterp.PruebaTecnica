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
                return ApiResponse<object>.Fail("Debe registrar al menos un detalle.");

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
                            $"No existe presupuesto para el tipo de gasto {det.ExpenseTypeId} en {request.Date.Month}/{request.Date.Year}."
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
                            Presupuesto = budget.AllocatedAmount,
                            Gastado = spent,
                            GastoNuevo = det.Amount,
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
                    return ApiResponse<object>.Fail("Presupuesto sobregirado.", exceeded);
                }

                await _uow.SaveChangesAsync();
                await trx.CommitAsync();

                return ApiResponse<object>.Ok(new { id = header.Id }, "Gasto registrado correctamente.");
            }
            catch (Exception ex)
            {
                await trx.RollbackAsync();
                return ApiResponse<object>.Fail($"Error registrando gasto: {ex.Message}");
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
                return ApiResponse<ExpenseHeaderDto?>.Fail("Gasto no encontrado.");

            var mapped = _mapper.Map<ExpenseHeaderDto>(entity);
            return ApiResponse<ExpenseHeaderDto?>.Ok(mapped);
        }

        public async Task<ApiResponse<string>> DeleteAsync(int id)
        {
            var header = await _uow.Expenses.GetByIdAsync(id);

            if (header == null)
                return ApiResponse<string>.Fail("Gasto no encontrado.");

            _uow.Expenses.RemoveHeader(header);

            await _uow.SaveChangesAsync();

            return ApiResponse<string>.Ok("Gasto eliminado correctamente.");
        }
    }
}