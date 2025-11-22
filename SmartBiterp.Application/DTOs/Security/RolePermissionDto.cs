namespace SmartBiterp.Application.DTOs.Security
{
    public class RolePermissionDto
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public string RoleName { get; set; } = string.Empty;
        public string PermissionCode { get; set; } = string.Empty;
        public string PermissionDescription { get; set; } = string.Empty;
    }
}
