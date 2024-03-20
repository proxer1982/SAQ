using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Interfaces
{
    public interface ITeamRepository : IGenericRepository<Team>
    {
        Task<IEnumerable<Team>> GetTeams();
    }
}
