using Microsoft.AspNetCore.Mvc;

using SmartBiterp.Application.DTOs.Expense;
using SmartBiterp.Application.Interfaces.Expense;
using SmartBiterp.Shared.Common.Responses;

namespace SmartBiterp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseTypeController : ControllerBase
    {
        private readonly IExpenseTypeService _service;

        public ExpenseTypeController(IExpenseTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<ExpenseTypeDto>>.Ok(result));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound(ApiResponse<string>.Fail($"Expense type with ID {id} not found."));

            return Ok(ApiResponse<ExpenseTypeDto>.Ok(result));
        }

        [HttpGet("next-code")]
        public async Task<IActionResult> GetNextCode()
        {
            var code = await _service.GetNextCodeAsync();
            return Ok(ApiResponse<object>.Ok(new { nextCode = code }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExpenseTypeRequest request)
        {
            var id = await _service.CreateAsync(request);

            return CreatedAtAction(
                nameof(GetById),
                new { id = id },
                ApiResponse<object>.Ok(new { id })
            );
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateExpenseTypeRequest request)
        {
            if (id != request.Id)
                return BadRequest(ApiResponse<string>.Fail("The id in the URL does not match the request body."));

            await _service.UpdateAsync(request);
            return Ok(ApiResponse<string>.Ok("Expense type updated successfully."));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(ApiResponse<string>.Ok("Expense type deleted successfully."));
        }
    }
}