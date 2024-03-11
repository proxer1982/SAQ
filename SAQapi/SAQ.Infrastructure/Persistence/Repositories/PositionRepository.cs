using Microsoft.EntityFrameworkCore;

using SAQ.Domain.Entities;
using SAQ.Infrastructure.Persistence.Context;
using SAQ.Infrastructure.Persistence.Interfaces;

namespace SAQ.Infrastructure.Persistence.Repositories
{
    internal class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        private readonly SAQContext _context;
        public PositionRepository(SAQContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Position>> GetPositions()
        {
            try
            {
                var menuList = new List<Position>();

                menuList = await _context
                    .Positions
                    .Where(p => p.Status.Equals(1))
                    .AsNoTracking()
                    .ToListAsync();

                return menuList;
            }
            catch
            {
                throw;
            }
        }
    }
}
