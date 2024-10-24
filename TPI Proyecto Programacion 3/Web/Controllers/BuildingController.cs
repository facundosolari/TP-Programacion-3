using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Interfaces;
using Application.Models.BuildingModels.Request;
using Application.Models.BuildingModels.Response;
using Application.Services;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingController : ControllerBase
    {
        private readonly IBuilding _buildingService;
        private static readonly List<Building> Buildings = new List<Building>();

        [HttpGet]
       // public IActionResult GetInmueble([FromQuery] string ubication, [FromBody] string type, [FromBody] string location, [FromBody] int id, [FromBody] string address, [FromBody] int bathrooms, [FromBody] int ambientes, [FromBody] bool garage, [FromBody] bool patio, [FromBody] List<string> fotos, [FromBody] string descripcion)
       // {
       //     return Ok();
       // }

       // [HttpPost]
       // public IActionResult CreateBuilding([FromBody] string ubication, [FromBody] int id, [FromBody] string address, [FromBody] int bathrooms, [FromBody] int rooms, [FromBody] bool garage, [FromBody] bool backyard, [FromBody] List<string> pictures, [FromBody] string description, [FromBody] int? userid, [FromBody] bool isAuthorized)
       // {
       //     var building = new Building(ubication, id, address, bathrooms, rooms, garage, backyard, pictures, description, userid, isAuthorized);
       //     Buildings.Add(building);
       //     return Created();
       // }

        [HttpPost]
        public IActionResult CreateBuilding([FromBody] BuildingRequest building)
        {
            
                var response = new BuildingResponse();
                string locationUrl = string.Empty;

                try
                {
                    response = _buildingService.Create(building);

                    string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                    string apiAndEndpointUrl = $"api/buildings/{response.Id}";
                    locationUrl = $"{baseUrl}/{apiAndEndpointUrl}";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                return Created(locationUrl, response);
            }

        
    }
}
