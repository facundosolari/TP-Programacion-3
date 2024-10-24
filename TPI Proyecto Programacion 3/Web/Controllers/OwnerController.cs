using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Models.OwnerModels.Response;
using Application.Models.OwnerModels.Request;
using Application.Interfaces;
using Application.Services;
using Application.Models.AppartmentModels.Request;
using System.Linq.Expressions;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        // inyeccion de dependencia 
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
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

        [HttpGet("{id}")]
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

        [HttpPost]
        public IActionResult CreateOwner([FromBody] CreateOwnerRequest owner)
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

        [HttpPut("{id}")]
        public IActionResult UpdateOwner([FromRoute] int id, [FromBody] UpdateOwnerRequest owner)
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

        [HttpDelete("{id}")]
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