using Contract.ReservationModels.Request;
using Contract.ReservationModels.Response;

namespace Application.Interfaces
{
    public interface IReservationService
    {
        ReservationResponse CreateReservation(ReservationRequest request);
        void CancelReservation(int reservationId);
    }
}
