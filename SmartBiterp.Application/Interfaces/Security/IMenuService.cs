using SmartBiterp.Domain.Entities.Security;

namespace SmartBiterp.Application.Interfaces.Security
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> GetAllAsync();
        Task<Menu?> GetByIdAsync(int id);
        Task<Menu> CreateAsync(Menu menu);
    }
}
