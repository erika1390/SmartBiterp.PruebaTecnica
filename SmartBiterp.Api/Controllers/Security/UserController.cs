using Microsoft.AspNetCore.Mvc;

using SmartBiterp.Application.Interfaces.Security;
using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Shared.Common.Responses;

namespace SmartBiterp.Api.Controllers.Security
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<User>>.Ok(data));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return data == null
                ? NotFound(ApiResponse<User?>.Fail("User not found."))
                : Ok(ApiResponse<User?>.Ok(data));
        }

        [HttpGet("by-username/{username}")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var data = await _service.GetByUsernameAsync(username);
            return data == null
                ? NotFound(ApiResponse<User?>.Fail("User not found."))
                : Ok(ApiResponse<User?>.Ok(data));
        }

        [HttpPost]
        public async Task<IActionResult> Create(User request)
        {
            try
            {
                var result = await _service.CreateAsync(request);
                return Ok(ApiResponse<User>.Ok(result, "User created successfully."));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.Fail(ex.Message));
            }
        }
    }
}
