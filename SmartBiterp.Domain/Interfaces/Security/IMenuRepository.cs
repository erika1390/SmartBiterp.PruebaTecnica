using SmartBiterp.Domain.Entities.Security;

namespace SmartBiterp.Domain.Interfaces.Security
{
    public interface IMenuRepository
    {
        Task<Menu?> GetByIdAsync(int id);
        Task<IEnumerable<Menu>> GetAllAsync();
        Task AddAsync(Menu menu);
    }
}
