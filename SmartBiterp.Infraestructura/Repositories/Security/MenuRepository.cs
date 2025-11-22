using Microsoft.EntityFrameworkCore;

using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Domain.Interfaces.Security;
using SmartBiterp.Infrastructure.Persistence.Context;

namespace SmartBiterp.Infrastructure.Repositories.Security
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _context;

        public MenuRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
        }

        public async Task<IEnumerable<Menu>> GetAllAsync()
        {
            return await _context.Menus
                .Include(m => m.Children)
                .Include(m => m.MenuRoles)
                    .ThenInclude(mr => mr.Role)
                .ToListAsync();
        }

        public async Task<Menu?> GetByIdAsync(int id)
        {
            return await _context.Menus
                .Include(m => m.Children)
                .Include(m => m.MenuRoles)
                    .ThenInclude(mr => mr.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
