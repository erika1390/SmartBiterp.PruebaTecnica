using SmartBiterp.Domain.Entities.Base;

namespace SmartBiterp.Domain.Entities.Security
{
    public class Menu : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;

        public int? ParentId { get; set; }
        public Menu? Parent { get; set; }

        public ICollection<Menu> Children { get; set; } = new List<Menu>();
        public ICollection<MenuRole> MenuRoles { get; set; } = new List<MenuRole>();
    }
}
