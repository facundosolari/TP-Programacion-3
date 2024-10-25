using Application.Interfaces;
using Contract.ReservationModels.Request;
using Contract.ReservationModels.Response;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IAppartmentRepository _appartmentRepository;

        public ReservationService(IReservationRepository reservationRepository, IAppartmentRepository appartmentRepository)
        {
            _reservationRepository = reservationRepository;
            _appartmentRepository = appartmentRepository;
        }

        public ReservationResponse CreateReservation(ReservationRequest request)
        {
            var appartment = _appartmentRepository.GetById(request.AppartmentID);
            if (appartment == null || !appartment.IsAvailable)
                throw new Exception("El departamento no está disponible.");

            // Verificar si ya hay una reserva para esa fecha
            var existingReservations = _reservationRepository.GetReservationsByAppartment(request.AppartmentID)
                .Where(r => r.VisitDate == request.VisitDate).ToList();
            if (existingReservations.Count > 0)
                throw new Exception("El departamento ya está reservado para esta fecha.");

            var reservation = new Reservation
            {
                AppartmentID = request.AppartmentID,
                TenantID = request.TenantID,
                VisitDate = request.VisitDate,
                Status = "Reserved"
            };

            _reservationRepository.CreateReservation(reservation);

            return new ReservationResponse
            {
                ReservationID = reservation.ReservationID,
                AppartmentID = reservation.AppartmentID,
                AppartmentDescription = appartment.Description,
                TenantID = reservation.TenantID,
                TenantName = reservation.Tenant.Name,
                VisitDate = reservation.VisitDate,
                Status = reservation.Status
            };
        }

        public void CancelReservation(int reservationId)
        {
            var reservation = _reservationRepository.GetReservationById(reservationId);
            if (reservation == null)
                throw new Exception("Reserva no encontrada.");

            if (reservation.VisitDate < DateTime.Now)
                throw new Exception("No se puede cancelar una reserva pasada.");

            _reservationRepository.CancelReservation(reservation);
        }
    }
}
