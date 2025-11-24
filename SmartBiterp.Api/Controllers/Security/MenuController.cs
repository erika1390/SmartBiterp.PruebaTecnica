using Microsoft.AspNetCore.Mvc;

using SmartBiterp.Application.Interfaces.Security;
using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Shared.Common.Responses;

namespace SmartBiterp.Api.Controllers.Security
{
    [ApiController]
    [Route("api/menus")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _service;

        public MenuController(IMenuService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<Menu>>.Ok(data));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return data == null
                ? NotFound(ApiResponse<Menu?>.Fail("Menu not found."))
                : Ok(ApiResponse<Menu?>.Ok(data));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Menu menu)
        {
            var result = await _service.CreateAsync(menu);
            return Ok(ApiResponse<Menu>.Ok(result, "Menu created successfully."));
        }
    }
}
