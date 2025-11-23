using SmartBiterp.Domain.Entities.Expense;

namespace SmartBiterp.Domain.Interfaces.Expense
{
    public interface IExpenseRepository
    {
        Task AddHeaderAsync(ExpenseHeader header);
        Task AddDetailAsync(ExpenseDetail detail);
        Task<ExpenseHeader?> GetByIdAsync(int id);
        Task<IEnumerable<ExpenseHeader>> GetExpensesByDateRangeAsync(DateTime start, DateTime end);
        Task<decimal> GetTotalSpentAsync(int year, int month, int expenseTypeId);
        void RemoveHeader(ExpenseHeader header);
    }
}
