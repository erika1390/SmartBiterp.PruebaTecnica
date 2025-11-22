using SmartBiterp.Domain.Entities.Expense;

namespace SmartBiterp.Domain.Interfaces.Expense
{
    public interface IBudgetRepository
    {
        Task AddAsync(Budget entity);
        Task<Budget?> GetBudgetAsync(int expenseTypeId, int month, int year);
        Task<decimal> GetExecutedAmountAsync(int expenseTypeId, int month, int year);
    }
}
