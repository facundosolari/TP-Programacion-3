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
        public IActionResult Get()
        {
        return Ok(new List<Admin>
        {
            new Admin { Username = "Admin", Password ="Admin123", Name = "Nombre Del Admin", Lastname ="Apellido Del Admin", Email ="mail@deladmin.com" },
            new Admin { Username = "Admin", Password ="Admin123", Name = "Nombre Del Admin", Lastname ="Apellido Del Admin", Email ="mail@deladmin.com" },
            new Admin { Username = "Admin", Password ="Admin123", Name = "Nombre Del Admin", Lastname ="Apellido Del Admin", Email ="mail@deladmin.com" },
        });
        }
    }
}
