using SmartBiterp.Domain.Entities.Security;

namespace SmartBiterp.Application.Interfaces.Security
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> GetAllAsync();
        Task<Permission?> GetByIdAsync(int id);
        Task<Permission> CreateAsync(Permission permission);
    }
}
