using Application.Models.ReservationModels;
using Domain.Entities;

namespace Contract.Mappings
{
    public static class ReservationProfile
    {
        public static Reservation ToReservationEntity(int id, ReservationRequest request)
        {
            return new Reservation
            {
                AppartmentID = id,
                TenantID = request.TenantID,
                VisitDate = request.VisitDate,
            };
        }

        public static ReservationResponse ToReservationResponse(Reservation reservation)
        {
            return new ReservationResponse
            {
                ReservationID = reservation.ReservationID,
                AppartmentID = reservation.AppartmentID,
                TenantID = reservation.TenantID,
                VisitDate = reservation.VisitDate,
            };
        }
    }
}
