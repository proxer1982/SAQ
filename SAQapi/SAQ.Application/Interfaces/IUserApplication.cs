using SAQ.Application.Commons.Bases;
using SAQ.Application.Dtos.Request;
using SAQ.Application.Dtos.Response;
using SAQ.Domain.Entities;
using SAQ.Utilities.Statics;

namespace SAQ.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<BaseResponse<IEnumerable<User>>> GetAllUsers(ICollection<StatusType> status);
        Task<BaseResponse<UserResponseDto>> GetUserById(Guid userId);

        Task<BaseResponse<RegisterResponseDto>> RegisterUser(UserRequestDto requestDto); // esta funbcion retorna si el registro fue exitoso y el tkn para poder inicializar el usuario desde el correo
        public Task<BaseResponse<bool>> EditUser(Guid userId, UserRequestDto requestUser);
        public Task<BaseResponse<bool>> RemoveUser(Guid userId);
        public Task<BaseResponse<string>> GenerateToken(TokenRequestDto requestDto);
        public Task<BaseResponse<string>> InitUser(InitRequestDto requestDto);

        Task<BaseResponse<bool>> GetUserByMail(string email);
    }
}
