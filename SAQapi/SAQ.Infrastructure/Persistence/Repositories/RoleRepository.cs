using Microsoft.EntityFrameworkCore;

using SAQ.Domain.Entities;
using SAQ.Infrastructure.Persistence.Context;
using SAQ.Infrastructure.Persistence.Interfaces;

namespace SAQ.Infrastructure.Persistence.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly SAQContext _context;
        public RoleRepository(SAQContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            try
            {
                var getById = await _context.Roles.Where(a => a.RoleId.Equals(id)).Include(a => a.PermissonRoles).SingleOrDefaultAsync(x => x.RoleId.Equals(id));
                return getById!;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ICollection<int>> GetPermissonsByRole(int id)
        {
            var permisonsR = new List<int>();

            var tempR = await _context.Roles.Where(x => x.RoleId.Equals(id)).Include(x => x.PermissonRoles).FirstOrDefaultAsync();

            Console.WriteLine(tempR.PermissonRoles.ToList());
            if (tempR != null)
            {
                foreach (var permisson in tempR.PermissonRoles)
                {
                    Console.WriteLine("Estos son los eprmisos role");
                    Console.WriteLine(permisson.ToString());
                    permisonsR.Add(permisson.PermissonId);

                }
            }

            return permisonsR;
        }
    }
}
