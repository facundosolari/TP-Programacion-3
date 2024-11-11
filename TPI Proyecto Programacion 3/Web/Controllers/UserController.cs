using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getSelfUser")]
        public IActionResult GetUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return BadRequest("No se pudo obtener el ID del usuario desde el token.");
            }

            var userId = (int.Parse(userIdClaim));

            var userData = _userService.GetSelfUser(userId);

            if (userData == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            return Ok(userData);
        }
    }
}
