using Microsoft.AspNetCore.Mvc;

using SmartBiterp.Application.Interfaces.Security;
using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Shared.Common.Responses;

namespace SmartBiterp.Api.Controllers.Security
{
    [ApiController]
    [Route("api/menu-roles")]
    public class MenuRoleController : ControllerBase
    {
        private readonly IMenuRoleService _service;

        public MenuRoleController(IMenuRoleService service)
        {
            _service = service;
        }

        [HttpPost("assign")]
        public async Task<IActionResult> Assign(MenuRole request)
        {
            try
            {
                var result = await _service.AssignAsync(request);
                return Ok(ApiResponse<MenuRole>.Ok(result, "Menu assigned to role successfully."));
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
            return Ok(ApiResponse<IEnumerable<MenuRole>>.Ok(data));
        }

        [HttpGet("by-menu/{menuId:int}")]
        public async Task<IActionResult> GetByMenu(int menuId)
        {
            var data = await _service.GetByMenuIdAsync(menuId);
            return Ok(ApiResponse<IEnumerable<MenuRole>>.Ok(data));
        }

        [HttpDelete("{roleId:int}/{menuId:int}")]
        public async Task<IActionResult> Remove(int roleId, int menuId)
        {
            try
            {
                await _service.RemoveAsync(roleId, menuId);
                return Ok(ApiResponse<string>.Ok("Menu-role mapping removed successfully."));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.Fail(ex.Message));
            }
        }
    }
}
