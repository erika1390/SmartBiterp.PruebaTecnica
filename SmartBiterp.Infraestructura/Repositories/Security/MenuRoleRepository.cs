using Microsoft.EntityFrameworkCore;

using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Domain.Interfaces.Security;
using SmartBiterp.Infrastructure.Persistence.Context;

namespace SmartBiterp.Infrastructure.Repositories.Security
{
    public class MenuRoleRepository : IMenuRoleRepository
    {
        private readonly AppDbContext _context;

        public MenuRoleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(MenuRole entity)
        {
            bool exists = await _context.MenuRoles
                .AnyAsync(mr => mr.RoleId == entity.RoleId && mr.MenuId == entity.MenuId);

            if (exists)
                throw new InvalidOperationException("This role is already assigned to the menu.");

            await _context.MenuRoles.AddAsync(entity);
        }

        public async Task<MenuRole?> GetAsync(int roleId, int menuId)
        {
            return await _context.MenuRoles
                .Include(mr => mr.Menu)
                .Include(mr => mr.Role)
                .FirstOrDefaultAsync(mr => mr.RoleId == roleId && mr.MenuId == menuId);
        }

        public async Task<IEnumerable<MenuRole>> GetByRoleIdAsync(int roleId)
        {
            return await _context.MenuRoles
                .Include(mr => mr.Menu)
                .Where(mr => mr.RoleId == roleId)
                .ToListAsync();
        }

        public async Task<IEnumerable<MenuRole>> GetByMenuIdAsync(int menuId)
        {
            return await _context.MenuRoles
                .Include(mr => mr.Role)
                .Where(mr => mr.MenuId == menuId)
                .ToListAsync();
        }

        public async Task RemoveAsync(MenuRole entity)
        {
            _context.MenuRoles.Remove(entity);
            await Task.CompletedTask;
        }
    }
}
