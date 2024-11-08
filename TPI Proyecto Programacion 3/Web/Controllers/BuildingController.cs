using Microsoft.AspNetCore.Mvc;
using Application.Models.BuildingModels.Response;
using Application.Models.BuildingModels.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Domain.Entities;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
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

        [HttpGet("getById/{id}")]
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

        [HttpPost("create")]
        [Authorize(Roles = "Admin,Owner")]
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

        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin,Owner")]
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

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin,Owner")]
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
    }
}
