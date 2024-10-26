using Application.Interfaces;
using Domain.Interfaces;
using Contract.Mappings;
using Application.Models.ReservationModels;

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

        public ReservationResponse CreateReservation(int id, ReservationRequest request)
        {
            var appartment = _appartmentRepository.GetById(id);
            if (appartment == null || !appartment.IsAvailable)
                throw new Exception("El departamento no está disponible.");

            // Verificar si ya hay una reserva para esa fecha
            var existingReservations = _reservationRepository.GetReservationsByAppartment(id)
                .Where(r => r.VisitDate == request.VisitDate).ToList();
            if (existingReservations.Count > 0)
                throw new Exception("El departamento ya está reservado para esta fecha.");

            var reservation = ReservationProfile.ToReservationEntity(id, request);

            _reservationRepository.CreateReservation(reservation);

            return ReservationProfile.ToReservationResponse(reservation);
        }

        public void CancelReservation(int id, ReservationRequest request)
        {
            var reservation = _reservationRepository.GetReservationById(id);
            if (reservation == null)
                throw new Exception("Reserva no encontrada.");

            if (request.TenantID != reservation.TenantID) throw new Exception("El inquilino no reservó una visita a este departamento.");

            if (reservation.VisitDate < DateOnly.FromDateTime(DateTime.Now))
                throw new Exception("No se puede cancelar una reserva pasada.");

            _reservationRepository.CancelReservation(reservation);
        }
    }
}
