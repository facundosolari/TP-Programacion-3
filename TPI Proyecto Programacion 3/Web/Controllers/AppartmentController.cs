using Application.Interfaces;
using Application.Models.AppartmentModels.Request;
using Application.Models.AppartmentModels.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppartmentController : ControllerBase
    {
        private readonly IAppartmentService _appartmentService;

        public AppartmentController(IAppartmentService appartmentService)
        {
            _appartmentService = appartmentService;
        }


        // GET: api/<Appartment>
        [HttpGet]
        public ActionResult<List<AppartmentResponse>> GetAllAppartments()
        {
            try
            {
                var response = _appartmentService.GetAll();
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAppartmentById([FromRoute] int id)
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
        [Authorize(Roles = "Admin,Owner")]
        public IActionResult CreateAppartment([FromBody] AppartmentRequest appartment)
        {

            try
            {
                var response = _appartmentService.Create(appartment);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Owner")]
        public ActionResult UpdateAppartment([FromRoute] int id, [FromBody] AppartmentRequest appartment)
        {
            try
            {
                var response = _appartmentService.UpdateAppartment(id, appartment);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Owner")]
        public ActionResult DeleteAppartment([FromRoute] int id)
        {
            try
            {
                var response = _appartmentService.DeleteAppartment(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }


        [HttpPost("{id}/calificar")]
        [Authorize(Roles = "Admin,Tenant")]
        public IActionResult AddRating(int id, [FromBody] RatingRequest ratingRequest)
        {
            try
            {
                _appartmentService.AddRating(id, ratingRequest);
                return Ok("Departamento calificado correctamente.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}