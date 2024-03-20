using AutoMapper;

using Microsoft.Extensions.Configuration;

using SAQ.Application.Commons.Bases;
using SAQ.Application.Interfaces;
using SAQ.Domain.Entities;
using SAQ.Infrastructure.Persistence.Interfaces;
using SAQ.Utilities.Statics;

namespace SAQ.Application.Services
{
    public class MenuApplication : IMenuApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public MenuApplication(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _config = config;
        }
        public async Task<BaseResponse<IEnumerable<Menu>>> GetMenuByUser(Guid userId)
        {
            var response = new BaseResponse<IEnumerable<Menu>>();

            List<int> permisos = (List<int>)await _unitOfWork.User.GetPermissonsByUser(userId);

            var menus = await _unitOfWork.Menu.GetMenuByPermissons(permisos);

            if (menus is not null)
            {
                response.Data = menus;
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
