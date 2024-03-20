namespace SAQ.Infrastructure.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool EnsureCreated();

        IRoleRepository Role { get; }
        IUserRepository User { get; }
        IPermissonRepository Permisson { get; }
        IMenuRepository Menu { get; }
        IPositionRepository Position { get; }
        ITeamRepository Team { get; }
        IStudyRepository Study { get; }

        /* Declaracion o matricula de nuestras interfaces a nivel de repositorio */
        //ICategoryRepository Category { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
