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
                new Propietario { Id = 1, Name = "Facundo", Surname = "Solari", Password ="solari123", Email ="facusolari9@gmail.com" },
                new Propietario { Id = 2, Name = "Nicolas", Surname = "Garcia", Password ="nico123", Email ="nico@gmail.com" },
                new Propietario { Id = 3, Name = "Francisco", Surname = "Rossi", Password ="fran123", Email ="fran@gmail.com" },
                new Propietario { Id = 4, Name = "Geraldine", Surname = "Martinez", Password ="geri123", Email ="geri@gmail.com" }




            });
        }
    }
}
