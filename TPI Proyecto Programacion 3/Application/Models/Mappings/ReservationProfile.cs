using Contract.ReservationModels.Request;
using Contract.ReservationModels.Response;
using Domain.Entities;

namespace Contract.Mappings
{
    public static class ReservationProfile
    {
        // Convierte de ReservationRequest a la entidad Reservation
        public static Reservation ToReservationEntity(ReservationRequest request)
        {
            return new Reservation
            {
                AppartmentID = request.AppartmentID,
                TenantID = request.TenantID,
                VisitDate = request.VisitDate,
                Status = "Reserved" // Estado por defecto
            };
        }

        // Convierte de la entidad Reservation a ReservationResponse
        public static ReservationResponse ToReservationResponse(Reservation reservation, Appartment appartment, Tenant tenant)
        {
            return new ReservationResponse
            {
                ReservationID = reservation.ReservationID,
                AppartmentID = reservation.AppartmentID,
                AppartmentDescription = appartment.Description,
                TenantID = reservation.TenantID,
                TenantName = tenant.Name,
                VisitDate = reservation.VisitDate,
                Status = reservation.Status
            };
        }
    }
}
