using Microsoft.AspNetCore.Mvc;

using SmartBiterp.Application.DTOs.Expense;
using SmartBiterp.Application.Interfaces.Expense;

namespace SmartBiterp.Api.Controllers.Expense
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepositController : ControllerBase
    {
        private readonly IDepositService _service;

        public DepositController(IDepositService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDepositRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.CreateAsync(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetByDateRange(
           [FromQuery] DateTime start,
           [FromQuery] DateTime end)
        {
            if (start > end)
                return BadRequest("La fecha inicial no puede ser mayor a la fecha final.");

            var result = await _service.GetByDateRangeAsync(start, end);
            return Ok(result);
        }
    }
}
