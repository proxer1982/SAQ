using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SAQ.Application.Interfaces;

namespace SAQ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionApplication _positionApplication;

        public PositionController(IPositionApplication postionApplication)
        {
            _positionApplication = postionApplication;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPostions()
        {
            var response = await _positionApplication.GetPositions();

            return Ok(response);
        }
    }
}
