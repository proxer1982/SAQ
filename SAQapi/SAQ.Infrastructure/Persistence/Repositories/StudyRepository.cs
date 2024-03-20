using SAQ.Domain.Entities;
using SAQ.Infrastructure.Persistence.Context;
using SAQ.Infrastructure.Persistence.Interfaces;

namespace SAQ.Infrastructure.Persistence.Repositories
{
    internal class StudyRepository : GenericRepository<Study>, IStudyRepository
    {
        private readonly SAQContext _context;
        public StudyRepository(SAQContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> RegisterAsync(Study study)
        {
            try
            {
                await _context.AddAsync(study);
                var recordsAffected = await _context.SaveChangesAsync();

                return recordsAffected > 0;
            }
            catch
            {
                throw;
            }
        }
    }
}
