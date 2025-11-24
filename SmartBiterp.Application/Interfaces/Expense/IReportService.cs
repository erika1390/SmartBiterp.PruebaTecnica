using SmartBiterp.Shared.Common.Responses;

namespace SmartBiterp.Application.Interfaces.Expense
{
    public interface IReportService
    {
        Task<ApiResponse<IEnumerable<object>>> GetBudgetVsExecutionAsync(DateTime start, DateTime end);
        Task<ApiResponse<IEnumerable<object>>> GetMovementsAsync(DateTime start, DateTime end);
    }
}
