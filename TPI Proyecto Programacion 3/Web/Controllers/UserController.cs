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

        [HttpGet("getSelfUser/{id}")]
        public IActionResult GetUser([FromRoute] int id)
        {

            var userData = _userService.GetSelfUser(id);

            if (userData == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            return Ok(userData);
        }
    }
}
