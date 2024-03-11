using AutoMapper;

using Microsoft.Extensions.Configuration;

using SAQ.Application.Commons.Bases;
using SAQ.Application.Interfaces;
using SAQ.Domain.Entities;
using SAQ.Infrastructure.Persistence.Interfaces;
using SAQ.Utilities.Statics;

namespace SAQ.Application.Services
{
    public class PositionApplication : IPositionApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public PositionApplication(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _config = config;
        }
        public async Task<BaseResponse<IEnumerable<Position>>> GetPositions()
        {
            var response = new BaseResponse<IEnumerable<Position>>();

            var req = await _unitOfWork.Position.GetPositions();

            if (req is not null)
            {
                response.Data = req;
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;

        }
    }
}
