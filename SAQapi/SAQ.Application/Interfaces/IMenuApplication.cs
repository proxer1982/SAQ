using SAQ.Application.Commons.Bases;
using SAQ.Domain.Entities;

namespace SAQ.Application.Interfaces
{
    public interface IMenuApplication
    {
        Task<BaseResponse<IEnumerable<Menu>>> GetMenuByUser(Guid userId);
    }
}
