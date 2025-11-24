using SmartBiterp.Application.DTOs.Expense;
using SmartBiterp.Shared.Common.Responses;

namespace SmartBiterp.Application.Interfaces.Expense
{
    public interface IDepositService
    {
        Task<ApiResponse<int>> CreateAsync(CreateDepositRequest request);
        Task<ApiResponse<IEnumerable<DepositDto>>> GetByDateRangeAsync(DateTime start, DateTime end);
    }
}
