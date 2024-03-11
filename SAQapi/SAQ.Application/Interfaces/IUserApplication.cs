using SAQ.Application.Commons.Bases;
using SAQ.Application.Dtos.Request;
using SAQ.Application.Dtos.Response;
using SAQ.Domain.Entities;
using SAQ.Utilities.Statics;

namespace SAQ.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<BaseResponse<IEnumerable<User>>> GetAllUsers(StatusType status);
        Task<BaseResponse<UserResponseDto>> GetUserById(Guid userId);

        Task<BaseResponse<bool>> RegisterUser(UserRequestDto requestDto);
        public Task<BaseResponse<bool>> EditUser(Guid userId, UserRequestDto requestUser);
        public Task<BaseResponse<bool>> RemoveUser(Guid userId);
        Task<BaseResponse<string>> GenerateToken(TokenRequestDto requestDto);

        Task<BaseResponse<bool>> GetUserByMail(string email);
        /*
        Task<BaseResponse<BaseEntityResponse<UserResponseDto>>> GetListUsers(BaseFiltersRequest filters);
        Task<BaseResponse<bool>> RegisterUser(UserRequestDto requestUser);
        Task<BaseResponse<bool>> EditUser(int userId, UserRequestDto requestUser);
        Task<BaseResponse<bool>> RemoveUser(int userId);*/
    }
}
