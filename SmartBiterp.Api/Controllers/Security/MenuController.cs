using Microsoft.AspNetCore.Mvc;
using SmartBiterp.Application.Interfaces.Security;
using SmartBiterp.Application.DTOs.Security;   // <-- IMPORTANTE
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
            var data = await _service.GetAllAsync();   // <-- YA DEVUELVE DTO
            return Ok(ApiResponse<IEnumerable<MenuDto>>.Ok(data));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetByIdAsync(id);

            return data == null
                ? NotFound(ApiResponse<MenuDto?>.Fail("Menu not found."))
                : Ok(ApiResponse<MenuDto?>.Ok(data));
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuDto menuDto)
        {
            var result = await _service.CreateAsync(menuDto);
            return Ok(ApiResponse<MenuDto>.Ok(result, "Menu created successfully."));
        }
    }
}
