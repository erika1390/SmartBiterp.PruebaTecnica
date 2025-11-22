using SmartBiterp.Domain.Entities.Expense;

namespace SmartBiterp.Domain.Interfaces.Expense
{
    public interface IBudgetRepository
    {
        Task<bool> ExistsAsync(int expenseTypeId, int year, int month);
        Task<IEnumerable<Budget>> GetByMonthAsync(int year, int month);
        Task<Budget?> GetByIdAsync(int id);
        Task AddAsync(Budget entity);
        void Remove(Budget entity);
    }
}
