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
        /*
        public async Task<BaseResponse<IEnumerable<RoleResponseDto>>> GetAllRoles()
        {
            var response = new BaseResponse<IEnumerable<RoleResponseDto>>();
            var roles = await _unitOfWork.Role.GetAllAsync();

            if (roles is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<RoleResponseDto>>(roles);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message += ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }


        public async Task<BaseResponse<RoleResponseDto>> GetRoleById(int roleId)
        {
            var response = new BaseResponse<RoleResponseDto>();
            var role = await _unitOfWork.User.GetByIdAsync(roleId);

            if (role is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<RoleResponseDto>(role);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message += ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> RegisterRole(UserRequestDto requestRole)
        {
            var response = new BaseResponse<bool>();

            var role = _mapper.Map<Role>(requestRole);
            response.Data = await _unitOfWork.Role.RegisterAsync(role);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> EditRole(int roleId, RoleRequestDto requestRole)
        {
            var response = new BaseResponse<bool>();
            var roleEdit = await GetRoleById(roleId);
            if (roleEdit.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            var role = _mapper.Map<Role>(requestRole);
            role.Id = roleId;

            response.Data = await _unitOfWork.Role.EditAsync(role);

            if (response.Data)
            {
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

        public async Task<BaseResponse<bool>> RemoveRole(int roleId)
        {
            var response = new BaseResponse<bool>();
            var roleEdit = await GetRoleById(roleId);
            if (roleEdit.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }


            response.Data = await _unitOfWork.Role.RemoveAsync(roleId);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }

        public Task<BaseResponse<bool>> RegisterRole(RoleRequestDto requestRole)
        {
            throw new NotImplementedException();
        }*/
    }
}
