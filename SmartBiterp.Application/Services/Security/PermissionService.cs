using Microsoft.Extensions.Logging;

using SmartBiterp.Application.Interfaces.Security;
using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Domain.Interfaces.Security;

namespace SmartBiterp.Application.Services.Security
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _repository;
        private readonly ILogger<PermissionService> _logger;

        public PermissionService(IPermissionRepository repository, ILogger<PermissionService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all permissions");
            return await _repository.GetAllAsync();
        }

        public async Task<Permission?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Retrieving permission with ID {Id}", id);
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Permission> CreateAsync(Permission permission)
        {
            _logger.LogInformation("Creating new permission '{Code}'", permission.Code);
            await _repository.AddAsync(permission);
            return permission;
        }
    }
}