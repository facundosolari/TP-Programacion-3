using Application.Interfaces;
using Application.Services;
using Contract.AppartmentModels.Request;
using Contract.AppartmentModels.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppartmentController : ControllerBase
    {
        private readonly IAppartmentService _appartmentService;
        private static readonly List<Appartment> Apparments = new List<Appartment>();

        public AppartmentController(IAppartmentService appartmentService)
        {
            _appartmentService = appartmentService;
        }


        // GET: api/<Appartment>
        [HttpGet]
        public ActionResult<List<AppartmentResponse>> GetAllAppartments()
        {
            var response = new List<AppartmentResponse>();

            try
            {
                response = _appartmentService.GetAll();
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
        public ActionResult<List<AppartmentResponse>> GetAppartmentById([FromRoute] int id)
        {
            var response = new AppartmentResponse();

            try
            {
                response = _appartmentService.GetById(id);

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
        
        public IActionResult CreateAppartment([FromBody] AppartmentRequest appartment)
        {
            var response = new AppartmentResponse();

            string locationUrl = string.Empty;

            try
            {
                response = _appartmentService.Create(appartment);

                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndpointUrl = $"api/apparments/{response.Id}";
                locationUrl = $"{baseUrl}/{apiAndEndpointUrl}";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Created(locationUrl, response);
        }

        [HttpPut("{id}")]
        public ActionResult<bool> UpdateAppartment([FromRoute] int id, [FromBody] AppartmentRequest appartment)
        {
            return Ok(_appartmentService.UpdateAppartment(id, appartment));
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteAppartment([FromRoute] int id)
        {
            return Ok(_appartmentService.DeleteAppartment(id));
        }
    }
}

