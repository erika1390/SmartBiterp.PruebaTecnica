using SmartBiterp.Domain.Entities.System;

namespace SmartBiterp.Domain.Interfaces.System
{
    public interface IAuditLogRepository
    {
        Task AddAsync(AuditLog log);
    }
}
