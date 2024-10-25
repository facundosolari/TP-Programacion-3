using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IReservationRepository
    {
        void CreateReservation(Reservation reservation);
        List<Reservation> GetReservationsByAppartment(int appartmentId);
        Reservation? GetReservationById(int reservationId);
        void CancelReservation(Reservation reservation);
    }
}
