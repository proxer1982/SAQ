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
            Console.WriteLine("estos son los permisos");
            Console.WriteLine(permisos);

            var menus = await _unitOfWork.Menu.GetMenuByPermissons(permisos);

            if (menus is not null)
            {
                response.Data = menus;
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            /*var roleId = await _unitOfWork.User.GetRoleIdAsync(userId);

            var permissons = _unitOfWork.Permisson.GetPermissonsUser(userId, roleId);

            if (permissons is not null)
            {
                response.IsSuccess = true;
                response.Data = (IEnumerable<Permisson>?)permissons;
            }
            else
            {
                response.IsSuccess = false;
            }


            //var account = await _unitOfWork.Perm.GetPermissonsUser(userId, roleId);
            */
            return response;
        }
    }
}
