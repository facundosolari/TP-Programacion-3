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
                new Propietario { Username = "MrSolari10", Password = "MrSolari123", Nombre = "Facundo", Apellido ="Solari", Email ="facusolari9@gmail.com", Rating = 5 },
                new Propietario { },
                new Propietario {},
                new Propietario { }        
             });
        }
    }
}