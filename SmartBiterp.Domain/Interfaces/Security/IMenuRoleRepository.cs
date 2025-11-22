using SmartBiterp.Domain.Entities.Security;

namespace SmartBiterp.Domain.Interfaces.Security
{
    public interface IMenuRoleRepository
    {
        Task<IEnumerable<MenuRole>> GetByRoleIdAsync(int roleId);
        Task<IEnumerable<MenuRole>> GetByMenuIdAsync(int menuId);

        Task<MenuRole?> GetAsync(int roleId, int menuId);
        Task AddAsync(MenuRole entity);
        Task RemoveAsync(MenuRole entity);
    }
}
