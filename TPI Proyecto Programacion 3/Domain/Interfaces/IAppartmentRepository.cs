using Domain.Entities;

namespace Domain.Interfaces;

public interface IAppartmentRepository
{
    void Create(Appartment entity);
    List<Appartment> GetAll();
    Appartment? GetById(int id);
    void UpdateAppartment(Appartment appartment);
    void DeleteAppartment(Appartment appartment);
    List<Rating> GetRatingsByAppartmentId(int appartmentId);
}