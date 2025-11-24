using Microsoft.Extensions.Logging;

using SmartBiterp.Application.Interfaces.Security;
using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Domain.Interfaces.Security;

namespace SmartBiterp.Application.Services.Security
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _repository;
        private readonly ILogger<MenuService> _logger;

        public MenuService(IMenuRepository repository, ILogger<MenuService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Menu>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all menus");
            return await _repository.GetAllAsync();
        }

        public async Task<Menu?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Retrieving menu with ID {Id}", id);
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Menu> CreateAsync(Menu menu)
        {
            _logger.LogInformation("Creating new menu: {Name}", menu.Title);
            await _repository.AddAsync(menu);
            return menu;
        }
    }
}
