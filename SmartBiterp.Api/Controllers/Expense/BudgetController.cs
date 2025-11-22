using Microsoft.AspNetCore.Mvc;

using SmartBiterp.Application.DTOs.Expense;
using SmartBiterp.Application.Interfaces.Expense;
using SmartBiterp.Shared.Common.Responses;

namespace SmartBiterp.Api.Controllers.Expense
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _service;

        public BudgetController(IBudgetService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetByMonth([FromQuery] int year, [FromQuery] int month)
        {
            if (year <= 0 || month < 1 || month > 12)
                return BadRequest(ApiResponse<string>.Fail("Invalid year or month."));

            var result = await _service.GetByMonthAsync(year, month);

            return Ok(ApiResponse<IEnumerable<BudgetDto>>.Ok(result));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound(ApiResponse<string>.Fail($"Budget with ID {id} not found."));

            return Ok(ApiResponse<BudgetDto>.Ok(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBudgetRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse<string>.Fail("Validation failed."));

            var newId = await _service.CreateAsync(request);

            return Ok(ApiResponse<object>.Ok(new { id = newId }, "Budget created successfully."));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBudgetRequest request)
        {
            if (id != request.Id)
                return BadRequest(ApiResponse<string>.Fail("ID in URL does not match the request."));

            await _service.UpdateAsync(request);

            return Ok(ApiResponse<string>.Ok("Budget updated successfully."));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(ApiResponse<string>.Ok("Budget deleted successfully."));
        }
    }
}
