using Application.Interfaces;
using Application.Services;
using Contract.ReservationModels.Request;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IActionResult CreateReservation([FromBody] ReservationRequest request)
        {
            try
            {
                var response = _reservationService.CreateReservation(request);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult CancelReservation(int id)
        {
            try
            {
                _reservationService.CancelReservation(id);
                return Ok("Reserva cancelada con éxito.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
