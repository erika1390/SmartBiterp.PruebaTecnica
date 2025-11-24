using Microsoft.AspNetCore.Mvc;

using SmartBiterp.Application.Interfaces.Security;
using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Shared.Common.Responses;

namespace SmartBiterp.Api.Controllers.Security
{
    [ApiController]
    [Route("api/permissions")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _service;

        public PermissionController(IPermissionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<Permission>>.Ok(data));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return data == null
                ? NotFound(ApiResponse<Permission?>.Fail("Permission not found."))
                : Ok(ApiResponse<Permission?>.Ok(data));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Permission permission)
        {
            try
            {
                var result = await _service.CreateAsync(permission);
                return Ok(ApiResponse<Permission>.Ok(result, "Permission created successfully."));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.Fail(ex.Message));
            }
        }
    }
}
