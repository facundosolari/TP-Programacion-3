using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
namespace Web.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController] 
    public class AdminController : ControllerBase
{
        [HttpGet]
        public IActionResult Get ()
        {
        return Ok(new List<Admin>
        {
            new Admin { Username = "Admin", Password ="Admin123", Nombre = "Nombre Del Admin", Apellido ="Apellido Del Admin", Email ="mail@deladmin.com" },
            new Admin { Username = "Admin", Password ="Admin123", Nombre = "Nombre Del Admin", Apellido ="Apellido Del Admin", Email ="mail@deladmin.com" },
            new Admin { Username = "Admin", Password ="Admin123", Nombre = "Nombre Del Admin", Apellido ="Apellido Del Admin", Email ="mail@deladmin.com" },
        }
            );
        }
    }
}
