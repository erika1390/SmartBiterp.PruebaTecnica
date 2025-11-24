using SmartBiterp.Application.DTOs.Security;

namespace SmartBiterp.Application.Interfaces.Security
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuDto>> GetAllAsync();
        Task<MenuDto?> GetByIdAsync(int id);
        Task<MenuDto> CreateAsync(MenuDto dto);
    }
}
