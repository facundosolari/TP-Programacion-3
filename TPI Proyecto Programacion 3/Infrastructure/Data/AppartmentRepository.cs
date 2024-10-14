using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Data
{
    public class AppartmentRepository : IAppartmentRepository
    {
        private readonly AppartmentsContext _dbContext;

        public AppartmentRepository(AppartmentsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Appartment entity)
        {
            _dbContext.Appartments.Add(entity);
            _dbContext.SaveChanges();
        }

        public List<Appartment> GetAll()
        {
            return _dbContext.Appartments.ToList();
        }

        public Appartment? GetById(int id)
        {
            return _dbContext.Appartments.FirstOrDefault(x => x.Id == id);
        }
    }
}
