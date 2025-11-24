using SmartBiterp.Domain.Entities.Base;

using System.Text.Json.Serialization;

namespace SmartBiterp.Domain.Entities.Security
{
    public class Menu : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;

        public int? ParentId { get; set; }

        [JsonIgnore]
        public Menu? Parent { get; set; }

        public ICollection<Menu> Children { get; set; } = new List<Menu>();

        [JsonIgnore]
        public ICollection<MenuRole> MenuRoles { get; set; } = new List<MenuRole>();
    }
}
