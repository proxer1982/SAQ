using SAQ.Infrastructure.Commons.Bases.Request;

using System.Linq.Expressions;

namespace SAQ.Infrastructure.Persistence.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        /*
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> RegisterAsync(T entity);
        Task<bool> EditAsync(T entity);
        Task<bool> RemoveAsync(int id);*/
        IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null);
        IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest paginationRequest, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class;
    }
}
