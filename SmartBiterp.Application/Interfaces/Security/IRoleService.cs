using SmartBiterp.Domain.Entities.Security;

namespace SmartBiterp.Application.Interfaces.Security
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(int id);
        Task<Role> CreateAsync(Role role);
    }
}
