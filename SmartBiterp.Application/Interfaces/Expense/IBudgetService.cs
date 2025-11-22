using SmartBiterp.Application.DTOs.Expense;

namespace SmartBiterp.Application.Interfaces.Expense
{
    public interface IBudgetService
    {
        Task<int> CreateAsync(CreateBudgetRequest request);
        Task UpdateAsync(UpdateBudgetRequest request);
        Task DeleteAsync(int id);
        Task<BudgetDto?> GetByIdAsync(int id);
        Task<IEnumerable<BudgetDto>> GetByMonthAsync(int year, int month);
    }
}
