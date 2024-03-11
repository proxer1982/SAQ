using Microsoft.EntityFrameworkCore;

using SAQ.Domain.Entities;
using SAQ.Infrastructure.Persistence.Context;
using SAQ.Infrastructure.Persistence.Interfaces;

namespace SAQ.Infrastructure.Persistence.Repositories
{
    public class PermissonRepository : GenericRepository<Permisson>, IPermissonRepository
    {
        private readonly SAQContext _context;

        public PermissonRepository(SAQContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Permisson>> GetPermissonsUser(Guid id, int roleId)
        {
            //var reg = await _context.Permissons.Where(p => p.Status.Equals(1)).ToListAsync();

            var perUser = await _context.PermissonsUser.Where(p => p.UserId.Equals(id)).Select(p => p.Permisson).ToListAsync();


            //var permissons = new List<int>();

            //var permissons = reg.Union(reglas).ToList();


            /*foreach (var permisson in reglas)
            {
                permissons.Add(permisson.Permisson);
            }*/
            Console.WriteLine("Este es el resultado 5:");
            Console.WriteLine(perUser);

            return perUser;
        }
    }
}
