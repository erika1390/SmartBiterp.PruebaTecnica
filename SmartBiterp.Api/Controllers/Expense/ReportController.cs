using Microsoft.AspNetCore.Mvc;

using SmartBiterp.Application.Interfaces.Expense;
using SmartBiterp.Shared.Common.Responses;

namespace SmartBiterp.Api.Controllers.Expense
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }
        [HttpGet("budget-vs-execution")]
        public async Task<IActionResult> GetBudgetVsExecution(
            [FromQuery] DateTime start,
            [FromQuery] DateTime end)
        {
            if (start > end)
                return BadRequest(ApiResponse<string>.Fail("La fecha inicial no puede ser mayor que la final."));

            var result = await _service.GetBudgetVsExecutionAsync(start, end);
            return Ok(result);
        }

        [HttpGet("movements")]
        public async Task<IActionResult> GetMovements(
            [FromQuery] DateTime start,
            [FromQuery] DateTime end)
        {
            if (start > end)
                return BadRequest(ApiResponse<string>.Fail("La fecha inicial no puede ser mayor que la final."));

            var result = await _service.GetMovementsAsync(start, end);
            return Ok(result);
        }
    }
}
