using SAQ.Domain.Entities;
using SAQ.Infrastructure.Commons.Bases.Request;
using SAQ.Infrastructure.Commons.Bases.Response;
using SAQ.Utilities.Statics;

namespace SAQ.Infrastructure.Persistence.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> RegisterAsync(User entity);
        Task<bool> EditAsync(User user);
        Task<bool> RemoveAsync(Guid id);
        Task<BaseEntityResponse<User>> GetListUsers(BaseFiltersRequest filters);

        Task<IEnumerable<User>> GetAllAsync(ICollection<StatusType> status);
        Task<User> GetByIdAsync(Guid id);
        Task<ICollection<int>> GetPermissonsByUser(Guid id);

        Task<User> AccountByUserName(string userName);
        Task<int> GetRoleIdAsync(Guid userId);

        void DetachUser(User user);
    }
}
