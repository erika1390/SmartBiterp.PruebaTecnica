using SmartBiterp.Application.DTOs.Expense;

namespace SmartBiterp.Application.Interfaces.Expense
{
    public interface IExpenseTypeService
    {
        Task<IEnumerable<ExpenseTypeDto>> GetAllAsync();
        Task<ExpenseTypeDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateExpenseTypeRequest request);
        Task UpdateAsync(UpdateExpenseTypeRequest request);
        Task DeleteAsync(int id);
        Task<string> GetNextCodeAsync();
    }
}
