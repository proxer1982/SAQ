using AutoMapper;

using SAQ.Application.Dtos.Request;
using SAQ.Application.Dtos.Response;
using SAQ.Domain.Entities;
using SAQ.Infrastructure.Commons.Bases.Response;
using SAQ.Utilities.Statics;

namespace SAQ.Application.Mappers
{
    public class UserMappingProfile : Profile

    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponseDto>()
                .ForMember(x => x.UserId, x => x.MapFrom(y => y.UserId))
                .ForMember(e => e.StatusUser, e => e.MapFrom(y => y.Status.Equals((int)StatusType.active) ? "Activo" : "Inactivo"))
                .ReverseMap();

            CreateMap<BaseEntityResponse<User>, BaseEntityResponse<UserResponseDto>>()
                 .ReverseMap();

            CreateMap<UserRequestDto, User>();
        }
    }
}
