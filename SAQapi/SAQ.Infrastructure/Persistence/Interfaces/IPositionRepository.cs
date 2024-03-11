using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Interfaces
{
    public interface IPositionRepository : IGenericRepository<Position>
    {
        Task<IEnumerable<Position>> GetPositions();
    }
}
