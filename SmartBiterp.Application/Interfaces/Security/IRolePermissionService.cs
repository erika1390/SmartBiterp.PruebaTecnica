using SmartBiterp.Domain.Entities.Security;

namespace SmartBiterp.Application.Interfaces.Security
{
    public interface IRolePermissionService
    {
        Task<RolePermission> AssignAsync(RolePermission entity);
        Task<RolePermission?> GetAsync(int roleId, int permissionId);
        Task<IEnumerable<RolePermission>> GetByRoleIdAsync(int roleId);
        Task<IEnumerable<RolePermission>> GetByPermissionIdAsync(int permissionId);
        Task RemoveAsync(int roleId, int permissionId);
    }
}
