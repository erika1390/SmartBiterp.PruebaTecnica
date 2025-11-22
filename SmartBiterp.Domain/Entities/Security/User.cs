using SmartBiterp.Domain.Entities.Base;

namespace SmartBiterp.Domain.Entities.Security
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}
