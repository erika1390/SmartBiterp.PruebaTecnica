using SmartBiterp.Domain.Entities.System;
using SmartBiterp.Domain.Interfaces.System;
using SmartBiterp.Infrastructure.Persistence.Context;

namespace SmartBiterp.Infrastructure.Repositories.System
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly AppDbContext _context;

        public AuditLogRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(AuditLog log)
        {
            throw new NotImplementedException();
        }
    }
}
