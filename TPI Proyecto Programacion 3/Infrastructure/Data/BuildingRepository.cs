using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Data;

public class BuildingRepository : IBuildingRepository
{
    private readonly ProjectContext _dbContext;

    public BuildingRepository(ProjectContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(Building entity)
    {
        _dbContext.Buildings.Add(entity);
        _dbContext.SaveChanges();
    }

    public List<Building> GetAll()
    {
        return _dbContext.Buildings.ToList();
    }

    public Building? GetById(int id)
    {
        return _dbContext.Buildings.FirstOrDefault(m => m.Id.Equals(id));
    }

    public void UpdateBuilding(Building entity)
    {
        _dbContext.Buildings.Update(entity);
        _dbContext.SaveChanges();
    }

    public void DeleteBuilding(Building entity)
    {
        _dbContext.Buildings.Remove(entity);
        _dbContext.SaveChanges();
    }
}