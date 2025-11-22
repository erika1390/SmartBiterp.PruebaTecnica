using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Domain.Interfaces.Security;
using SmartBiterp.Infrastructure.Persistence.Context;

namespace SmartBiterp.Infrastructure.Repositories.Security
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
