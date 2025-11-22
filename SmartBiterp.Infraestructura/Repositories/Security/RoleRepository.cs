using Microsoft.EntityFrameworkCore;

using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Domain.Interfaces.Security;
using SmartBiterp.Infrastructure.Persistence.Context;

namespace SmartBiterp.Infrastructure.Repositories.Security
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Role role)
        {
            role.RoleType = role.RoleType;

            bool exists = await _context.Roles
                .AnyAsync(r => r.RoleType == role.RoleType);

            if (exists)
                throw new InvalidOperationException($"Role '{role.RoleType}' already exists.");

            await _context.Roles.AddAsync(role);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Roles
                .Include(r => r.Users)
                .Include(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                .Include(r => r.MenuRoles)
                    .ThenInclude(mr => mr.Menu)
                .OrderBy(r => r.RoleType)
                .ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _context.Roles
                .Include(r => r.Users)
                .Include(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                .Include(r => r.MenuRoles)
                    .ThenInclude(mr => mr.Menu)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
