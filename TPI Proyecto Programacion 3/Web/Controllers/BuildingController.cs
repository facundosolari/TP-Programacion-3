using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Interfaces;
using Contract.BuildingModels.Request;
using Contract.BuildingModels.Response;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;
        private static readonly List<Building> Buildings = new List<Building>();

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        public ActionResult<List<BuildingResponse>> GetAllBuildings()
        {
            try
            {
                var response = _buildingService.GetAll();
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBuildingById([FromRoute] int id)
        {
            try
            {
                var response = _buildingService.GetById(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateBuilding([FromBody] BuildingRequest building)
        {
            var response = new BuildingResponse();
            string locationUrl = string.Empty;

            try
            {
                response = _buildingService.Create(building);

                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndpointUrl = $"api/buildings/{response.BuildingId}";
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
