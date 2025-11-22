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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Permission?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
