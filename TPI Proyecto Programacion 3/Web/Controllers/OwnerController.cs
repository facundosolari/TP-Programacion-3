using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Services;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        // inyeccion de dependencia 
        private readonly OwnerService _ownerService;

        public OwnerController(OwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        // es para no instanciar directamente el objeto aca abajo
      //  public IActionResult GetOwner()
      //  {
      //      return Ok(_ownerService.GetOwnerService());
      //  }

      //  [HttpGet]
      //  public IActionResult Get()
      //  {
      //      return Ok(new List<Owner>
      //      {
      //          new Owner { Username = "MrSolari10", Password = "MrSolari123", Name = "Facundo", Lastname ="Solari", Email ="facusolari9@gmail.com", Rating = 5 },
      //          new Owner { },
      //          new Owner {},
      //          new Owner { }        
      //       });
      //  }
    }
}