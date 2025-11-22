using SmartBiterp.Domain.Entities.Base;

namespace SmartBiterp.Domain.Entities.Security
{
    public class MenuRole : BaseEntity
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; } = null!;

        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}