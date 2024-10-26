using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Data
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ProjectContext _dbContext;

        public ReservationRepository(ProjectContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateReservation(Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();
        }

        public List<Reservation> GetReservationsByAppartment(int appartmentId)
        {
            return _dbContext.Reservations.Where(r => r.AppartmentID == appartmentId).ToList();
        }

        public Reservation? GetReservationById(int reservationId)
        {
            return _dbContext.Reservations.FirstOrDefault(r => r.ReservationID == reservationId);
        }

        public void CancelReservation(Reservation reservation)
        {
            _dbContext.Reservations.Remove(reservation);
            _dbContext.SaveChanges();
        }
    }
}
