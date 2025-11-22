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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
