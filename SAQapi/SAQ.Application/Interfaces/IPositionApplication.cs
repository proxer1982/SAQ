using SAQ.Application.Commons.Bases;
using SAQ.Domain.Entities;

namespace SAQ.Application.Interfaces
{
    public interface IPositionApplication
    {
        Task<BaseResponse<IEnumerable<Position>>> GetPositions();
    }
}
