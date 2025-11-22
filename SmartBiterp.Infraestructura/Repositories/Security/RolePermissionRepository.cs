using Microsoft.EntityFrameworkCore;

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
            bool exists = await _context.RolePermissions
                .AnyAsync(rp => rp.RoleId == entity.RoleId && rp.PermissionId == entity.PermissionId);

            if (exists)
                throw new InvalidOperationException("This permission is already assigned to the role.");

            await _context.RolePermissions.AddAsync(entity);
        }

        public async Task<RolePermission?> GetAsync(int roleId, int permissionId)
        {
            return await _context.RolePermissions
                .Include(rp => rp.Role)
                .Include(rp => rp.Permission)
                .FirstOrDefaultAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId);
        }

        public async Task<IEnumerable<RolePermission>> GetByPermissionIdAsync(int permissionId)
        {
            return await _context.RolePermissions
                .Include(rp => rp.Role)
                .Where(rp => rp.PermissionId == permissionId)
                .ToListAsync();
        }

        public async Task<IEnumerable<RolePermission>> GetByRoleIdAsync(int roleId)
        {
            return await _context.RolePermissions
                .Include(rp => rp.Permission)
                .Where(rp => rp.RoleId == roleId)
                .OrderBy(rp => rp.Permission.Code)
                .ToListAsync();
        }

        public async Task RemoveAsync(RolePermission entity)
        {
            _context.RolePermissions.Remove(entity);
            await Task.CompletedTask;
        }
    }
}
