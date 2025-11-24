using SmartBiterp.Application.Interfaces.Expense;
using SmartBiterp.Domain.Interfaces;
using SmartBiterp.Shared.Common.Responses;

namespace SmartBiterp.Application.Services.Expense
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _uow;

        public ReportService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ApiResponse<IEnumerable<object>>> GetBudgetVsExecutionAsync(DateTime start, DateTime end)
        {
            var data = await _uow.Reports.GetBudgetVsExecutionAsync(start, end);

            return ApiResponse<IEnumerable<object>>.Ok(data, "Report generated successfully.");
        }

        public async Task<ApiResponse<IEnumerable<object>>> GetMovementsAsync(DateTime start, DateTime end)
        {
            var data = await _uow.Reports.GetMovementsAsync(start, end);

            return ApiResponse<IEnumerable<object>>.Ok(data, "Report generated successfully.");
        }
    }
}