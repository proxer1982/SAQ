using AutoMapper;

using Microsoft.Extensions.Configuration;

using SAQ.Application.Commons.Bases;
using SAQ.Application.Interfaces;
using SAQ.Domain.Entities;
using SAQ.Infrastructure.Persistence.Interfaces;
using SAQ.Utilities.Statics;

namespace SAQ.Application.Services
{
    public class TeamApplication : ITeamApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public TeamApplication(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _config = config;
        }
        public async Task<BaseResponse<IEnumerable<Team>>> GetTeams()
        {
            var response = new BaseResponse<IEnumerable<Team>>();

            var req = await _unitOfWork.Team.GetTeams();

            if (req is not null)
            {
                response.Data = req;
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_QUERY;
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
