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
            log.User = log.User?.Trim() ?? string.Empty;
            log.Entity = log.Entity?.Trim() ?? string.Empty;
            log.RecordId = log.RecordId?.Trim() ?? string.Empty;
            log.Detail = log.Detail?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(log.User))
                throw new ArgumentException("AuditLog requires a valid User.");

            if (string.IsNullOrWhiteSpace(log.Entity))
                throw new ArgumentException("AuditLog requires a valid Entity name.");

            await _context.AuditLogs.AddAsync(log);
        }
    }
}
