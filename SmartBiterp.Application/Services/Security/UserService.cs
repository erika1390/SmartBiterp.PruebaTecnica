using Microsoft.Extensions.Logging;

using SmartBiterp.Application.Interfaces.Security;
using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Domain.Interfaces.Security;

namespace SmartBiterp.Application.Services.Security
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository repository, ILogger<UserService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all users");
            return await _repository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Retrieving user with ID {Id}", id);
            return await _repository.GetByIdAsync(id);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            _logger.LogInformation("Retrieving user with username '{Username}'", username);
            return await _repository.GetByUsernameAsync(username);
        }

        public async Task<User> CreateAsync(User user)
        {
            _logger.LogInformation("Creating new user '{Username}'", user.Username);
            await _repository.AddAsync(user);
            return user;
        }
    }
}