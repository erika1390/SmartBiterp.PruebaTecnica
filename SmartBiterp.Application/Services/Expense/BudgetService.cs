using AutoMapper;

using SmartBiterp.Application.DTOs.Expense;
using SmartBiterp.Application.Interfaces.Expense;
using SmartBiterp.Domain.Entities.Expense;
using SmartBiterp.Domain.Enums;
using SmartBiterp.Domain.Interfaces;

namespace SmartBiterp.Application.Services.Expense
{
    public class BudgetService : IBudgetService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public BudgetService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<int> CreateAsync(CreateBudgetRequest request)
        {
            var exists = await _uow.Budgets.ExistsAsync(
                request.ExpenseTypeId,
                request.Year,
                request.Month
            );

            if (exists)
                throw new Exception("A budget already exists for this month and expense type.");

            var entity = new Budget
            {
                ExpenseTypeId = request.ExpenseTypeId,
                Year = request.Year,
                Month = request.Month,
                AllocatedAmount = request.AllocatedAmount,
                Status = BudgetStatusType.Normal
            };

            await _uow.Budgets.AddAsync(entity);
            await _uow.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _uow.Budgets.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Budget not found.");

            _uow.Budgets.Remove(entity);
            await _uow.SaveChangesAsync();
        }

        public async Task<BudgetDto?> GetByIdAsync(int id)
        {
            var entity = await _uow.Budgets.GetByIdAsync(id);

            return entity == null
                ? null
                : _mapper.Map<BudgetDto>(entity);
        }

        public async Task<IEnumerable<BudgetDto>> GetByMonthAsync(int year, int month)
        {
            var list = await _uow.Budgets.GetByMonthAsync(year, month);
            return _mapper.Map<IEnumerable<BudgetDto>>(list);
        }

        public async Task UpdateAsync(UpdateBudgetRequest request)
        {
            var entity = await _uow.Budgets.GetByIdAsync(request.Id);

            if (entity == null)
                throw new Exception("Budget not found.");

            entity.AllocatedAmount = request.AllocatedAmount;
            entity.Status = request.Status;

            await _uow.SaveChangesAsync();
        }
    }
}
