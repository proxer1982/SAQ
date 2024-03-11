using Microsoft.EntityFrameworkCore;

using SAQ.Infrastructure.Commons.Bases.Request;
using SAQ.Infrastructure.Helpers;
using SAQ.Infrastructure.Persistence.Context;
using SAQ.Infrastructure.Persistence.Interfaces;

using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace SAQ.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SAQContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(SAQContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }


        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            try
            {
                IQueryable<T> query = _entity;
                if (filter != null) query = query.Where(filter);

                return query;
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest paginationRequest, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class
        {
            try
            {
                IQueryable<TDTO> queryDto = (paginationRequest.Order == "desc") ? queryable.OrderBy($"{paginationRequest.Sort} descending") : queryable.OrderBy($"{paginationRequest.Sort} ascending");

                if (pagination) queryDto = queryDto.Paginate(paginationRequest);

                return queryDto;
            }
            catch
            {
                throw;
            }
        }

    }
}
