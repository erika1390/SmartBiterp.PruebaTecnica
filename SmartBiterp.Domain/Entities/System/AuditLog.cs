using SmartBiterp.Domain.Entities.Base;
using SmartBiterp.Domain.Enums;

namespace SmartBiterp.Domain.Entities.System
{
    public class AuditLog : BaseEntity
    {
        public string User { get; set; } = string.Empty;
        public AuditActionType Action { get; set; }
        public string Entity { get; set; } = string.Empty;
        public string RecordId { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;
    }
}
