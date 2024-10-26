using Application.Models.ReservationModels;
using Domain.Entities;

namespace Contract.Mappings
{
    public static class ReservationProfile
    {
        // Convierte de ReservationRequest a la entidad Reservation
        public static Reservation ToReservationEntity(int id, ReservationRequest request)
        {
            return new Reservation
            {
                AppartmentID = id,
                TenantID = request.TenantID,
                VisitDate = request.VisitDate,
                Status = "Reserved" // Estado por defecto
            };
        }

        // Convierte de la entidad Reservation a ReservationResponse
        public static ReservationResponse ToReservationResponse(Reservation reservation)
        {
            return new ReservationResponse
            {
                ReservationID = reservation.ReservationID,
                AppartmentID = reservation.AppartmentID,
                TenantID = reservation.TenantID,
                VisitDate = reservation.VisitDate,
                Status = reservation.Status
            };
        }
    }
}
