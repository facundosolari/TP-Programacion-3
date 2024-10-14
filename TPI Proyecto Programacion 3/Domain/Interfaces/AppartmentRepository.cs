using Domain.Entities;

namespace Domain.Interfaces;

public interface IAppartmentRepository
{
    void Create(Appartment entity);
    List<Appartment> GetAll();
    Appartment? GetById(int id);
}