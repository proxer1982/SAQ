using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SAQ.Application.Interfaces;

namespace SAQ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamApplication _teamApplication;

        public TeamController(ITeamApplication teamApplication)
        {
            _teamApplication = teamApplication;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetTeams()
        {
            var response = await _teamApplication.GetTeams();

            return Ok(response);
        }
    }
}
