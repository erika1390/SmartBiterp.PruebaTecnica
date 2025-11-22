using Microsoft.AspNetCore.Mvc;

using SmartBiterp.Application.DTOs.Expense;
using SmartBiterp.Application.Interfaces.Expense;
using SmartBiterp.Shared.Common.Responses;

namespace SmartBiterp.Api.Controllers.Expense
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoneyFundController : ControllerBase
    {
        private readonly IMoneyFundService _service;

        public MoneyFundController(IMoneyFundService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var funds = await _service.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<MoneyFundDto>>.Ok(funds));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var fund = await _service.GetByIdAsync(id);

            if (fund == null)
                return NotFound(ApiResponse<string>.Fail($"MoneyFund with ID {id} not found."));

            return Ok(ApiResponse<MoneyFundDto>.Ok(fund));
        }

        [HttpGet("next-code")]
        public async Task<IActionResult> GetNextCode()
        {
            var code = await _service.GetNextCodeAsync();
            return Ok(ApiResponse<object>.Ok(new { nextCode = code }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMoneyFundRequest request)
        {
            var id = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id }, ApiResponse<object>.Ok(new { id }));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMoneyFundRequest request)
        {
            if (id != request.Id)
                return BadRequest(ApiResponse<string>.Fail("The ID in the URL does not match the request body."));

            await _service.UpdateAsync(request);
            return Ok(ApiResponse<string>.Ok("MoneyFund updated successfully."));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(ApiResponse<string>.Ok("MoneyFund deleted successfully."));
        }
    }
}