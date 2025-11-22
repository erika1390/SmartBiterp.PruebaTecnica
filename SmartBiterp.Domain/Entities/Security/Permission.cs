using SmartBiterp.Domain.Entities.Base;

namespace SmartBiterp.Domain.Entities.Security
{
    public class Permission : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}