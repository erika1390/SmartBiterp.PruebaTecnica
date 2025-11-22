using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Domain.Interfaces.Security;
using SmartBiterp.Infrastructure.Persistence.Context;

namespace SmartBiterp.Infrastructure.Repositories.Security
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private readonly AppDbContext _context;

        public RolePermissionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(RolePermission entity)
        {
            throw new NotImplementedException();
        }

        public async Task<RolePermission?> GetAsync(int roleId, int permissionId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RolePermission>> GetByPermissionIdAsync(int permissionId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RolePermission>> GetByRoleIdAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(RolePermission entity)
        {
            throw new NotImplementedException();
        }
    }
}
