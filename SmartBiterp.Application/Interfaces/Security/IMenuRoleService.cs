using SmartBiterp.Domain.Entities.Security;

namespace SmartBiterp.Application.Interfaces.Security
{
    public interface IMenuRoleService
    {
        Task<MenuRole> AssignAsync(MenuRole entity);
        Task<MenuRole?> GetAsync(int roleId, int menuId);
        Task<IEnumerable<MenuRole>> GetByRoleIdAsync(int roleId);
        Task<IEnumerable<MenuRole>> GetByMenuIdAsync(int menuId);
        Task RemoveAsync(int roleId, int menuId);
    }
}
