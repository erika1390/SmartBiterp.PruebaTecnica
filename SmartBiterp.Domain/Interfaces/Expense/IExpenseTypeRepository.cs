using SmartBiterp.Domain.Entities.Expense;

namespace SmartBiterp.Domain.Interfaces.Expense
{
    public interface IExpenseTypeRepository
    {
        Task<IEnumerable<ExpenseType>> GetAllAsync();
        Task<ExpenseType?> GetByIdAsync(int id);
        Task AddAsync(ExpenseType entity);
        Task<string> GetNextCodeAsync();
        void Remove(ExpenseType entity);
    }
}
