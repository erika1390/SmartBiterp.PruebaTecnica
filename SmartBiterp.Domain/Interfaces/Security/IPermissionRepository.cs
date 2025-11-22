using SmartBiterp.Domain.Entities.Security;

namespace SmartBiterp.Domain.Interfaces.Security
{
    public interface IPermissionRepository
    {
        Task<Permission?> GetByIdAsync(int id);
        Task<IEnumerable<Permission>> GetAllAsync();
        Task AddAsync(Permission permission);
    }
}
