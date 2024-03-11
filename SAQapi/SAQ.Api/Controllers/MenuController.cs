using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SAQ.Application.Interfaces;

namespace SAQ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuApplication _menuApplication;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MenuController(IMenuApplication menuApplication, IHttpContextAccessor httpContextAccessor)
        {
            _menuApplication = menuApplication;
            _httpContextAccessor=httpContextAccessor;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMenus()
        {
            var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst("userId");
            if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out var userId))
            {
                return Unauthorized(); // Manejo de error si no se encuentra el usuario en el token o no es un Guid válido
            }

            var response = await _menuApplication.GetMenuByUser(userId);

            return Ok(response);
        }
    }
}
