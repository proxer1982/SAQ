using AutoMapper;

using SAQ.Application.Dtos.Response;
using SAQ.Domain.Entities;
using SAQ.Infrastructure.Commons.Bases.Response;

namespace SAQ.Application.Mappers
{
    public class PositionMappingProfile : Profile
    {
        public PositionMappingProfile()
        {
            CreateMap<Position, PositionResponseDto>()
                    .ForMember(x => x.PositionId, x => x.MapFrom(y => y.PositionId))
                    .ForMember(x => x.Title, x => x.MapFrom(y => y.Title))
                    .ReverseMap();

            CreateMap<BaseEntityResponse<Position>, BaseEntityResponse<PositionResponseDto>>()
                 .ReverseMap();
        }
    }
}
