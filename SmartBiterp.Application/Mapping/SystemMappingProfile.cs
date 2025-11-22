using AutoMapper;

using SmartBiterp.Application.DTOs.System;
using SmartBiterp.Domain.Entities.System;

namespace SmartBiterp.Application.Mapping
{
    public class SystemMappingProfile : Profile
    {
        public SystemMappingProfile()
        {
            CreateMap<AuditLog, AuditLogDto>()
                .ForMember(d => d.Action, opt => opt.MapFrom(s => s.Action.ToString()));
        }
    }
}
