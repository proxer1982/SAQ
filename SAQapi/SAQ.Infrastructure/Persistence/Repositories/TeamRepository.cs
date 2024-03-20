using Microsoft.EntityFrameworkCore;

using SAQ.Domain.Entities;
using SAQ.Infrastructure.Persistence.Context;
using SAQ.Infrastructure.Persistence.Interfaces;

namespace SAQ.Infrastructure.Persistence.Repositories
{
    internal class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        private readonly SAQContext _context;
        public TeamRepository(SAQContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetTeams()
        {
            try
            {
                var teamsList = new List<Team>();

                teamsList = await _context
                    .Teams
                    .Where(p => p.Status.Equals(1))
                    .AsNoTracking()
                    .ToListAsync();

                return teamsList;
            }
            catch
            {
                throw;
            }
        }
    }
}
