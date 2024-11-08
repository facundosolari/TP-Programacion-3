using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Application.Models.OwnerModels;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<OwnerResponse>> GetAllOwner()
        {
            try
            {
                var response = _ownerService.GetAll();
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpGet("getById/{id}")]
        [Authorize]
        public IActionResult GetOwnerById([FromRoute] int id)
        {
            try
            {
                var response = _ownerService.GetById(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpPost("create")]
        public IActionResult CreateOwner([FromBody] OwnerRequest owner)
        {
            try
            {
                var response = _ownerService.Create(owner);
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
        public IActionResult UpdateOwner([FromRoute] int id, [FromBody] OwnerRequest owner)
        {
            try
            {
                var response = _ownerService.UpdateOwner(id, owner);
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
        public IActionResult DeleteOwner([FromRoute] int id)
        {
            try
            {
                var response = _ownerService.DeleteOwner(id);
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