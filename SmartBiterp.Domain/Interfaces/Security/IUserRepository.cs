using SmartBiterp.Domain.Entities.Security;

namespace SmartBiterp.Domain.Interfaces.Security
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByUsernameAsync(string username);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
    }
}
