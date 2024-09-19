using Microsoft.AspNetCore.Mvc;
using Domain.Entities;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InmuebleController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInmueble([FromBody] string ubicacion, [FromBody] string tipo, [FromBody] string localidad, [FromBody] int id, [FromBody] string direccion, [FromBody] int baños, [FromBody] int ambientes, [FromBody] bool garage, [FromBody] bool patio, [FromBody] List<string> fotos, [FromBody] string descripcion)
        {
            return Ok();
        }
    }
}
