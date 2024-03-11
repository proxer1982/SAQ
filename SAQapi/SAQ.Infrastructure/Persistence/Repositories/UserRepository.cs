using Microsoft.EntityFrameworkCore;

using SAQ.Domain.Entities;
using SAQ.Infrastructure.Commons.Bases.Request;
using SAQ.Infrastructure.Commons.Bases.Response;
using SAQ.Infrastructure.Persistence.Context;
using SAQ.Infrastructure.Persistence.Interfaces;
using SAQ.Utilities.Statics;

using System.Linq.Dynamic.Core;

namespace SAQ.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly SAQContext _context;
        public UserRepository(SAQContext context) : base(context) { _context = context; }

        public async Task<User> AccountByUserName(string userName)
        {
            try
            {
                var account = await _context.Users.AsNoTracking().FirstOrDefaultAsync(e => e.UserName!.Equals(userName));
                return account!;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> RegisterAsync(User user)
        {
            try
            {
                user.UserId = Guid.NewGuid();
                user.UserCreated = Guid.Parse("be302144-78b1-4736-9b73-a81ec1516bc0");

                await _context.AddAsync(user);
                var recordsAffected = await _context.SaveChangesAsync();

                return recordsAffected > 0;
            }
            catch
            {
                throw;
            }
        }

        public void DetachUser(User user)
        {
            _context.Entry(user).State = EntityState.Detached;
        }
        public async Task<bool> EditAsync(User user)
        {
            try
            {
                user.UserUpdated = Guid.Parse("be302144-78b1-4736-9b73-a81ec1516bc0");
                user.DateUpdated = DateTime.UtcNow; // Asignar la fecha en formato UTC

                Console.WriteLine(user.UserId);

                _context.Users.Update(user);

                var recordsAffected = await _context.SaveChangesAsync();

                return recordsAffected > 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserId.Equals(id));

                user.Status = (int)StatusType.inactive;
                user.UserDeleted = Guid.Parse("be302144-78b1-4736-9b73-a81ec1516bc0");
                user.DateDeleted = DateTime.UtcNow; // Asignar la fecha en formato UTC


                _context.Update(user);

                var recordsAffected = await _context.SaveChangesAsync();

                return recordsAffected > 0;
            }
            catch
            {
                throw;
            }
        }




        public async Task<IEnumerable<User>> GetAllAsync(StatusType status)
        {
            try
            {
                var getAll = await _context.Users.Where(x => x.Status.Equals((int)status)).ToListAsync();

                return getAll;
            }
            catch
            {
                throw;
            }

        }


        public async Task<User> GetByIdAsync(Guid id)
        {
            try
            {
                var getById = await _context.Users.Where(x => x.UserId.Equals(id)).AsNoTracking().FirstOrDefaultAsync();

                return getById!;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ICollection<int>> GetPermissonsByUser(Guid id)
        {
            var permisons = new List<int>();
            var permisonsR = new List<int>();
            var roleId = 0;

            var temp = await _context.Users.Where(x => x.UserId.Equals(id)).Include(x => x.PermissonUsers).Include(x => x.Rol).ThenInclude(r => r.PermissonRoles).FirstOrDefaultAsync();

            if (temp != null)
            {
                roleId = temp.RoleId;

                foreach (var permisson in temp.PermissonUsers)
                {
                    permisons.Add(permisson.PermissonId);

                }

                foreach (var permisson in temp.Rol.PermissonRoles)
                {
                    permisonsR.Add(permisson.PermissonId);

                }
            }


            var result = permisons.Union(permisonsR).ToList();

            return result;
        }


        public async Task<BaseEntityResponse<User>> GetListUsers(BaseFiltersRequest filters)
        {
            try
            {
                var response = new BaseEntityResponse<User>();

                var users = GetEntityQuery(x => x.DateDeleted == null && x.UserDeleted == null);

                if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
                {
                    switch (filters.NumFilter)
                    {
                        case 1:
                            users = users.Where(u => u.UserName!.Contains(filters.TextFilter));
                            break;
                    }
                }

                if (filters.StateFilter is not null)
                {
                    users = users.Where(u => u.Status.Equals(filters.StateFilter));
                }

                if (!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
                {
                    users = users.Where(u => u.DateCreated >= DateTime.Parse(filters.StartDate).ToUniversalTime() && u.DateCreated <= DateTime.Parse(filters.EndDate).AddDays(1).ToUniversalTime());
                }

                if (filters.Sort is null) filters.Sort = "Id";

                response.TotalRecords = await users.CountAsync();
                response.Items = await Ordering(filters, users, !(bool)filters.Download!).ToListAsync();

                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> GetRoleIdAsync(Guid userId)
        {
            try
            {
                var roleId = await _context.Users.Where(u => u.UserId.Equals(userId)).Select(u => u.RoleId).FirstOrDefaultAsync();

                return (int)roleId;
            }
            catch
            {
                throw;
            }

        }
    }
}
