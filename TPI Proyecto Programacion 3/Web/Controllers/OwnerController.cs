using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Contract.OwnerModels.Response;
using Contract.OwnerModels.Request;
using Application.Interfaces;
using Application.Services;
using Contract.AppartmentModels.Request;
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
            var response = new List<OwnerResponse>();

            try
            {
                response = _ownerService.GetAll();
                if (response.Count is 0)
                {
                    return NotFound("No existe ningún propietario");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return response;
        }

        [HttpGet("{id}")]
        public ActionResult GetOwnerById([FromRoute] int id)
        {
            var response = new OwnerResponse();

            try
            {
                response = _ownerService.GetById(id);

                if (response is null)
                {
                    return NotFound($"No existe un propietario con id: {id}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateOwner([FromBody] CreateOwnerRequest owner)
        {
            var response = new OwnerResponse();

            try
            {
                response = _ownerService.Create(owner);

                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("error al crear owner");
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOwner([FromRoute] int id, [FromBody] UpdateOwnerRequest owner)
        {
            var response = new OwnerResponse();

            try
            {
                response = _ownerService.UpdateOwner(id, owner);
                if (response == null)
                {
                    return NotFound($"No existe un propietario con id: {id}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOwner([FromRoute] int id)
        {
            try
            {
                var owner = _ownerService.DeleteOwner(id);
                if (!owner)
                {
                    return NotFound($"No existe un propietario con id: {id}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok($"Propietario con id: {id} eliminado.");
        }
    }
}