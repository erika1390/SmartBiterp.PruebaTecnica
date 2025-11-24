using Microsoft.Extensions.Logging;

using SmartBiterp.Application.Interfaces.Security;
using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Domain.Interfaces.Security;

namespace SmartBiterp.Application.Services.Security
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IRolePermissionRepository _repository;
        private readonly ILogger<RolePermissionService> _logger;

        public RolePermissionService(IRolePermissionRepository repository, ILogger<RolePermissionService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<RolePermission> AssignAsync(RolePermission entity)
        {
            _logger.LogInformation("Assigning permission {PermissionId} to role {RoleId}", entity.PermissionId, entity.RoleId);
            await _repository.AddAsync(entity);
            return entity;
        }

        public async Task<RolePermission?> GetAsync(int roleId, int permissionId)
        {
            _logger.LogInformation("Retrieving role-permission mapping Role {RoleId}, Permission {PermissionId}", roleId, permissionId);
            return await _repository.GetAsync(roleId, permissionId);
        }

        public async Task<IEnumerable<RolePermission>> GetByRoleIdAsync(int roleId)
        {
            _logger.LogInformation("Retrieving permissions for role {RoleId}", roleId);
            return await _repository.GetByRoleIdAsync(roleId);
        }

        public async Task<IEnumerable<RolePermission>> GetByPermissionIdAsync(int permissionId)
        {
            _logger.LogInformation("Retrieving roles for permission {PermissionId}", permissionId);
            return await _repository.GetByPermissionIdAsync(permissionId);
        }

        public async Task RemoveAsync(int roleId, int permissionId)
        {
            _logger.LogInformation("Removing role-permission mapping Role {RoleId}, Permission {PermissionId}", roleId, permissionId);

            var entity = await _repository.GetAsync(roleId, permissionId);

            if (entity == null)
                throw new InvalidOperationException("Role-permission mapping not found.");

            await _repository.RemoveAsync(entity);
        }
    }
}