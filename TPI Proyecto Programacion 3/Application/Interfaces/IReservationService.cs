using Application.Models.ReservationModels;

namespace Application.Interfaces
{
    public interface IReservationService
    {
        ReservationResponse CreateReservation(int id, ReservationRequest request);
        void CancelReservation(int reservationId, ReservationRequest request);
    }
}
