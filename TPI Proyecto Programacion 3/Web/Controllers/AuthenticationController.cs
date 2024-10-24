using Microsoft.AspNetCore.Mvc;
using Application.Models.AuthenticationModels;
using Application.Interfaces;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ICustomAuthenticationService _customAuthenticationService;

        public AuthenticationController(IConfiguration config, ICustomAuthenticationService authenticationService)
        {
            _config = config;
            _customAuthenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] CredentialsRequest credentials)
        {
            string token = _customAuthenticationService.Autenticar(credentials);

            return Ok(token);
        }
    }
}
