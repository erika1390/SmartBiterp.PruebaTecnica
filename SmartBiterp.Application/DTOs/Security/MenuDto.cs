namespace SmartBiterp.Application.DTOs.Security
{
    public class MenuDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public List<MenuDto> Children { get; set; } = new();
    }
}
