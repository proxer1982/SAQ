using AutoMapper;

using SAQ.Application.Interfaces;
using SAQ.Infrastructure.Persistence.Interfaces;

namespace SAQ.Application.Services
{
    internal class RoleApplication : IRoleApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
