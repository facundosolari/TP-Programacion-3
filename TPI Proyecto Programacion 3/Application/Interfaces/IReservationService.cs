using Application.Models.ReservationModels.ReservationResponse;
using Application.Models.ReservationModels.ReservationRequest;

namespace Application.Interfaces
{
    public interface IReservationService
    {
        ReservationResponse CreateReservation(int id, ReservationRequest request);
        void CancelReservation(int reservationId, ReservationRequest request);
    }
}
