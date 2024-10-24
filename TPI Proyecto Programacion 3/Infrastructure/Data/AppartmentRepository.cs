using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppartmentRepository : IAppartmentRepository
    {
        private readonly ProjectContext _dbContext;

        public AppartmentRepository(ProjectContext dbContext)
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

        public void UpdateAppartment(Appartment entity)
        {
            _dbContext.Appartments.Update(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteAppartment(Appartment appartment)
        {
            _dbContext.Appartments.Remove(appartment);
            _dbContext.SaveChanges();
        }
    }
}
