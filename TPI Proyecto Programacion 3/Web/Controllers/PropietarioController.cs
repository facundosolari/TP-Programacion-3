using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropietarioController : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            return Ok(new List<Propietario>
            {
                new Propietario { },
                new Propietario { },
                new Propietario {},
                new Propietario { }




            });
        }
    }
}
