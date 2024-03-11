using AutoMapper;

using SAQ.Application.Dtos.Request;
using SAQ.Application.Dtos.Response;
using SAQ.Domain.Entities;
using SAQ.Infrastructure.Commons.Bases.Response;

namespace SAQ.Application.Mappers
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, RoleResponseDto>()
                .ForMember(x => x.RoleId, x => x.MapFrom(y => y.RoleId))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Role>, BaseEntityResponse<RoleResponseDto>>()
                 .ReverseMap();

            CreateMap<RoleRequestDto, Role>();
        }
    }
}
