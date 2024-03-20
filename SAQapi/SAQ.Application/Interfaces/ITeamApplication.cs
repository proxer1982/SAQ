using SAQ.Application.Commons.Bases;
using SAQ.Domain.Entities;

namespace SAQ.Application.Interfaces
{
    public interface ITeamApplication
    {
        Task<BaseResponse<IEnumerable<Team>>> GetTeams();
    }
}
