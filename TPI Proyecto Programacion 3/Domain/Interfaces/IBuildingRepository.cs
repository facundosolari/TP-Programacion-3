using Domain.Entities;

namespace Domain.Interfaces;

public interface IBuildingRepository
{
    void Create(Building entity);
    List<Building> GetAll();
    Building? GetById(int id);
    void UpdateBuilding(Building entity);
    void DeleteBuilding(Building entity);
}