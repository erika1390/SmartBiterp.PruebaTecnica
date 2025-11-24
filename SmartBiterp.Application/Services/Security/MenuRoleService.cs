using Microsoft.Extensions.Logging;

using SmartBiterp.Application.Interfaces.Security;
using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Domain.Interfaces.Security;

namespace SmartBiterp.Application.Services.Security
{
    public class MenuRoleService : IMenuRoleService
    {
        private readonly IMenuRoleRepository _repository;
        private readonly ILogger<MenuRoleService> _logger;

        public MenuRoleService(IMenuRoleRepository repository, ILogger<MenuRoleService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<MenuRole> AssignAsync(MenuRole entity)
        {
            _logger.LogInformation("Assigning menu {MenuId} to role {RoleId}", entity.MenuId, entity.RoleId);

            await _repository.AddAsync(entity);
            return entity;
        }

        public async Task<MenuRole?> GetAsync(int roleId, int menuId)
        {
            _logger.LogInformation("Retrieving menu-role mapping for Menu {MenuId}, Role {RoleId}", menuId, roleId);
            return await _repository.GetAsync(roleId, menuId);
        }

        public async Task<IEnumerable<MenuRole>> GetByRoleIdAsync(int roleId)
        {
            _logger.LogInformation("Retrieving menus for role {RoleId}", roleId);
            return await _repository.GetByRoleIdAsync(roleId);
        }

        public async Task<IEnumerable<MenuRole>> GetByMenuIdAsync(int menuId)
        {
            _logger.LogInformation("Retrieving roles for menu {MenuId}", menuId);
            return await _repository.GetByMenuIdAsync(menuId);
        }

        public async Task RemoveAsync(int roleId, int menuId)
        {
            _logger.LogInformation("Removing menu-role mapping. Menu {MenuId}, Role {RoleId}", menuId, roleId);

            var entity = await _repository.GetAsync(roleId, menuId);

            if (entity == null)
                throw new InvalidOperationException("Menu-role mapping not found.");

            await _repository.RemoveAsync(entity);
        }
    }
}