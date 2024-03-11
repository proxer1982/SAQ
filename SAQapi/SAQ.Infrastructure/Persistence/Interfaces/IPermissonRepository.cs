using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Interfaces
{
    public interface IPermissonRepository : IGenericRepository<Permisson>
    {
        Task<IEnumerable<Permisson>> GetPermissonsUser(Guid id, int roleId);
    }
}
