using Application.Interfaces;
using Application.Services;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Application.Models.ReservationModels.ReservationRequest;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("departamento/{id}")]
        [Authorize(Roles = "Tenant")]
        public IActionResult CreateReservation([FromRoute] int id, [FromBody] ReservationRequest request)
        {
            try
            {
                var response = _reservationService.CreateReservation(id, request);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("reservas/{id}")]
        [Authorize(Roles = "Admin,Tenant")]
        public IActionResult CancelReservation([FromRoute]int id, ReservationRequest request)
        {
            try
            {
                _reservationService.CancelReservation(id, request);
                return Ok("Reserva cancelada con éxito.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
