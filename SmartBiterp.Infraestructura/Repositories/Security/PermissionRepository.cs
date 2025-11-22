using Microsoft.EntityFrameworkCore;

using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Domain.Interfaces.Security;
using SmartBiterp.Infrastructure.Persistence.Context;

namespace SmartBiterp.Infrastructure.Repositories.Security
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly AppDbContext _context;

        public PermissionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Permission permission)
        {
            permission.Code = permission.Code.Trim();
            permission.Description = permission.Description.Trim();

            bool exists = await _context.Permissions
                .AnyAsync(p => p.Code.ToLower() == permission.Code.ToLower());

            if (exists)
                throw new InvalidOperationException($"A permission with code '{permission.Code}' already exists.");

            await _context.Permissions.AddAsync(permission);
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            return await _context.Permissions
                .Include(p => p.RolePermissions)
                    .ThenInclude(rp => rp.Role)
                .OrderBy(p => p.Code)
                .ToListAsync();
        }

        public async Task<Permission?> GetByIdAsync(int id)
        {
            return await _context.Permissions
                .Include(p => p.RolePermissions)
                    .ThenInclude(rp => rp.Role)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
