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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Menu>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Menu?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
