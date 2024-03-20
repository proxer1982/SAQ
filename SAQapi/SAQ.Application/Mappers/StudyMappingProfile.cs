using AutoMapper;

using SAQ.Application.Dtos.Request;
using SAQ.Domain.Entities;

namespace SAQ.Application.Mappers
{
    public class StudyMappingProfile : Profile
    {
        public StudyMappingProfile()
        {
            CreateMap<StudyRequestDto, Study>()
                 .ReverseMap();
        }
    }
}
