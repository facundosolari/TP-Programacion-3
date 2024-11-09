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
        public ActionResult Authenticate([FromBody] CredentialsRequest credentials)
        {
            try
            {
                var response = _customAuthenticationService.Authenticate(credentials);

                return Ok(response); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }
    }
}
