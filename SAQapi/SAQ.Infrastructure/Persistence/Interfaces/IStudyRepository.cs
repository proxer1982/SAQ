using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Interfaces
{
    public interface IStudyRepository : IGenericRepository<Study>
    {
        public Task<bool> RegisterAsync(Study study);

    }
}
