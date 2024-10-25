using Microsoft.AspNetCore.Mvc;
using Application.Models.AuthenticationModels;
using Application.Interfaces;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _customAuthenticationService;

        public AuthenticationController(IAuthenticationService autenticacionService)
        { 
            _customAuthenticationService = autenticacionService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] CredentialsRequest credentials)
        {
            string token = _customAuthenticationService.Authenticate(credentials);

            return Ok(token);
        }
    }
}
