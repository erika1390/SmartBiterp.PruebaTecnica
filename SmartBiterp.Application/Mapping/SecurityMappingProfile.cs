using AutoMapper;

using SmartBiterp.Application.DTOs.Security;
using SmartBiterp.Domain.Entities.Security;

namespace SmartBiterp.Application.Mapping
{
    public class SecurityMappingProfile : Profile
    {
        public SecurityMappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(d => d.RoleName, opt => opt.MapFrom(s => s.Role.RoleType.ToString()));

            CreateMap<Role, RoleDto>()
                .ForMember(d => d.RoleType, opt => opt.MapFrom(s => s.RoleType.ToString()));

            CreateMap<Permission, PermissionDto>();

            CreateMap<RolePermission, RolePermissionDto>()
                .ForMember(d => d.RoleName, opt => opt.MapFrom(s => s.Role.RoleType.ToString()))
                .ForMember(d => d.PermissionCode, opt => opt.MapFrom(s => s.Permission.Code))
                .ForMember(d => d.PermissionDescription, opt => opt.MapFrom(s => s.Permission.Description));

            CreateMap<Menu, MenuDto>()
                .ForMember(d => d.Children, opt => opt.MapFrom(s => s.Children))
                .ForMember(d => d.ParentId, opt => opt.MapFrom(s => s.ParentId))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Icon, opt => opt.MapFrom(s => s.Icon))
                .ForMember(d => d.Route, opt => opt.MapFrom(s => s.Route));

            CreateMap<MenuRole, MenuRoleDto>()
                .ForMember(d => d.RoleName, opt => opt.MapFrom(s => s.Role.RoleType.ToString()))
                .ForMember(d => d.MenuTitle, opt => opt.MapFrom(s => s.Menu.Title));
        }
    }
}