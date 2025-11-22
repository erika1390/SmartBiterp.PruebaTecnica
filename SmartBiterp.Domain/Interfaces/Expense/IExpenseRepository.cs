using SmartBiterp.Domain.Entities.Expense;

namespace SmartBiterp.Domain.Interfaces.Expense
{
    public interface IExpenseRepository
    {
        Task AddExpenseAsync(ExpenseHeader header, IEnumerable<ExpenseDetail> details);
        Task<IEnumerable<ExpenseHeader>> GetExpensesByDateRangeAsync(DateTime start, DateTime end);
        Task<decimal> GetTotalByTypeAsync(int expenseTypeId, int month, int year);
    }
}
