using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Models.BuildingModels.Response;
using Application.Models.BuildingModels.Request;
using Application.Interfaces;
using Application.Services;
using Application.Models.AppartmentModels.Request;
using System.Linq.Expressions;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        // Inyección de dependencia
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        public ActionResult<List<BuildingResponse>> GetAllBuilding()
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
            try
            {
                var response = _buildingService.Create(building);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBuilding([FromRoute] int id, [FromBody] BuildingRequest building)
        {
            try
            {
                var response = _buildingService.UpdateBuilding(id, building);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBuilding([FromRoute] int id)
        {
            try
            {
                var response = _buildingService.DeleteBuilding(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpPost("building/{buildingId}/{appartmentId}")]
        public IActionResult AssignAppartmentToBuilding([FromRoute] int buildingId, [FromRoute] int appartmentId)
        {
            try
            {
                var response = _buildingService.AssignAppartmentToBuilding(buildingId, appartmentId);
                return Ok("Asignación correcta");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

    }
}
