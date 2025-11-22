using SmartBiterp.Domain.Entities.Base;

namespace SmartBiterp.Domain.Entities.Security
{
    public class RolePermission : BaseEntity
    {
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public int PermissionId { get; set; }
        public Permission Permission { get; set; } = null!;

        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
        public string AssignedBy { get; set; } = string.Empty;
    }
}
