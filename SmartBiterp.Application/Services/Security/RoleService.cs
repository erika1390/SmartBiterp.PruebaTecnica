using Microsoft.Extensions.Logging;

using SmartBiterp.Application.Interfaces.Security;
using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Domain.Interfaces.Security;

namespace SmartBiterp.Application.Services.Security
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly ILogger<RoleService> _logger;

        public RoleService(IRoleRepository repository, ILogger<RoleService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all roles");
            return await _repository.GetAllAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Retrieving role with ID {Id}", id);
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Role> CreateAsync(Role role)
        {
            _logger.LogInformation("Creating new role '{RoleType}'", role.RoleType);
            await _repository.AddAsync(role);
            return role;
        }
    }
}