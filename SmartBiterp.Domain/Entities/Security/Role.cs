using SmartBiterp.Domain.Entities.Base;
using SmartBiterp.Domain.Enums;

namespace SmartBiterp.Domain.Entities.Security
{
    public class Role : BaseEntity
    {
        public RoleType RoleType { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
        public ICollection<MenuRole> MenuRoles { get; set; } = new List<MenuRole>();
    }
}