namespace SmartBiterp.Application.DTOs.Security
{
    public class MenuRoleDto
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }

        public string RoleName { get; set; } = string.Empty;
        public string MenuTitle { get; set; } = string.Empty;
    }
}
