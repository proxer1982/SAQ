using SAQ.Infrastructure.Persistence.Context;
using SAQ.Infrastructure.Persistence.Interfaces;

namespace SAQ.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SAQContext _context;

        public IRoleRepository Role { get; private set; }
        public IUserRepository User { get; private set; }
        public IPermissonRepository Permisson { get; private set; }
        public IMenuRepository Menu { get; private set; }
        public IPositionRepository Position { get; private set; }
        public ITeamRepository Team { get; private set; }
        public IStudyRepository Study { get; private set; }

        public UnitOfWork(SAQContext contexto)
        {
            _context = contexto;
            User = new UserRepository(_context);
            Role = new RoleRepository(_context);
            Permisson = new PermissonRepository(_context);
            Menu = new MenuRepository(_context);
            Position = new PositionRepository(_context);
            Team = new TeamRepository(_context);
            Study = new StudyRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public bool EnsureCreated()
        {
            return _context.Database.EnsureCreated();
        }
    }
}
