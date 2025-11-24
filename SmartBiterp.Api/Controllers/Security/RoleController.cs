using Microsoft.AspNetCore.Mvc;

using SmartBiterp.Application.Interfaces.Security;
using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Shared.Common.Responses;

namespace SmartBiterp.Api.Controllers.Security
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<Role>>.Ok(data));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return data == null
                ? NotFound(ApiResponse<Role?>.Fail("Role not found."))
                : Ok(ApiResponse<Role?>.Ok(data));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Role role)
        {
            try
            {
                var result = await _service.CreateAsync(role);
                return Ok(ApiResponse<Role>.Ok(result, "Role created successfully."));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.Fail(ex.Message));
            }
        }
    }
}
