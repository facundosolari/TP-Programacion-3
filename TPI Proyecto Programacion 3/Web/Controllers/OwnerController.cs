using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Contract.OwnerModels.Response;
using Contract.OwnerModels.Request;
using Application.Interfaces;

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
        public ActionResult<List<OwnerResponse>> GetOwnerById([FromRoute] int id)
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
            string locationUrl = string.Empty;

            try
            {
                response = _ownerService.Create(owner);

                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent}";
                string apiAndEndpointUrl = $"api/owners/{response.Id}";
                locationUrl = $"{baseUrl}/{apiAndEndpointUrl}";
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            return Created(locationUrl, response);
        }
    }
}