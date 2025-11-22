using SmartBiterp.Domain.Entities.Security;

namespace SmartBiterp.Domain.Interfaces.Security
{
    public interface IRolePermissionRepository
    {
        Task<IEnumerable<RolePermission>> GetByRoleIdAsync(int roleId);
        Task<IEnumerable<RolePermission>> GetByPermissionIdAsync(int permissionId);
        Task<RolePermission?> GetAsync(int roleId, int permissionId);
        Task AddAsync(RolePermission entity);
        Task RemoveAsync(RolePermission entity);
    }
}
