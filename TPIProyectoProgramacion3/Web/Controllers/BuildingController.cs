using Microsoft.AspNetCore.Mvc;
using Domain.Entities;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingController : ControllerBase
    {
        private static readonly List<Building> Buildings = new List<Building>();

        [HttpGet]
        public IActionResult GetInmueble([FromQuery] string ubication, [FromBody] string type, [FromBody] string location, [FromBody] int id, [FromBody] string address, [FromBody] int bathrooms, [FromBody] int ambientes, [FromBody] bool garage, [FromBody] bool patio, [FromBody] List<string> fotos, [FromBody] string descripcion)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateBuilding([FromBody] string ubication, [FromBody] string type, [FromBody] int id, [FromBody] string address, [FromBody] int bathrooms, [FromBody] int rooms, [FromBody] bool garage, [FromBody] bool backyard, [FromBody] List<string> pictures, [FromBody] string description, [FromBody] int userid)
        {
           var building = new Building(ubication, type, id, address, bathrooms, rooms, garage, backyard, pictures, description, userid);
           Buildings.Add(building);
            return Created();
        }
    }
}
