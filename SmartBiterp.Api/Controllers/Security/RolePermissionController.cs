using Microsoft.AspNetCore.Mvc;

using SmartBiterp.Application.Interfaces.Security;
using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Shared.Common.Responses;

namespace SmartBiterp.Api.Controllers.Security
{
    [ApiController]
    [Route("api/role-permissions")]
    public class RolePermissionController : ControllerBase
    {
        private readonly IRolePermissionService _service;

        public RolePermissionController(IRolePermissionService service)
        {
            _service = service;
        }

        [HttpPost("assign")]
        public async Task<IActionResult> Assign(RolePermission request)
        {
            try
            {
                var result = await _service.AssignAsync(request);
                return Ok(ApiResponse<RolePermission>.Ok(result, "Permission assigned to role successfully."));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.Fail(ex.Message));
            }
        }

        [HttpGet("by-role/{roleId:int}")]
        public async Task<IActionResult> GetByRole(int roleId)
        {
            var data = await _service.GetByRoleIdAsync(roleId);
            return Ok(ApiResponse<IEnumerable<RolePermission>>.Ok(data));
        }

        [HttpGet("by-permission/{permissionId:int}")]
        public async Task<IActionResult> GetByPermission(int permissionId)
        {
            var data = await _service.GetByPermissionIdAsync(permissionId);
            return Ok(ApiResponse<IEnumerable<RolePermission>>.Ok(data));
        }

        [HttpDelete("{roleId:int}/{permissionId:int}")]
        public async Task<IActionResult> Remove(int roleId, int permissionId)
        {
            try
            {
                await _service.RemoveAsync(roleId, permissionId);
                return Ok(ApiResponse<string>.Ok("Role-permission mapping removed successfully."));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.Fail(ex.Message));
            }
        }
    }
}
