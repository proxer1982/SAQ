using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<Role> GetByIdAsync(int id);

        Task<ICollection<int>> GetPermissonsByRole(int id);
    }
}
