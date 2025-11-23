using SmartBiterp.Application.DTOs.Expense;
using SmartBiterp.Shared.Common.Responses;

namespace SmartBiterp.Application.Interfaces.Expense
{
    public interface IExpenseService
    {
        Task<ApiResponse<object>> CreateAsync(CreateExpenseHeaderRequest request);
        Task<ApiResponse<IEnumerable<ExpenseHeaderDto>>> GetAllAsync();
        Task<ApiResponse<ExpenseHeaderDto?>> GetByIdAsync(int id);
        Task<ApiResponse<string>> DeleteAsync(int id);
    }
}
