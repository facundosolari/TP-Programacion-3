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
            return Ok(new List<Owner>
            {
                new Owner { Username = "MrSolari10", Password = "MrSolari123", Name = "Facundo", Lastname ="Solari", Email ="facusolari9@gmail.com", Rating = 5 },
                new Owner { },
                new Owner {},
                new Owner { }        
             });
        }
    }
}