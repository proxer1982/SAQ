using SAQ.Domain.Entities;

namespace SAQ.Infrastructure.Persistence.Interfaces
{
    public interface IMenuRepository : IGenericRepository<Menu>
    {
        Task<IEnumerable<Menu>> GetMenuByPermissons(IEnumerable<int> lista);
    }
}
