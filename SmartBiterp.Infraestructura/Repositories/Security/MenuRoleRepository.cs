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
            throw new NotImplementedException();
        }

        public async Task<MenuRole?> GetAsync(int roleId, int menuId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MenuRole>> GetByMenuIdAsync(int menuId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MenuRole>> GetByRoleIdAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(MenuRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
