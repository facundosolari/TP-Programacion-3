using Domain.Entities;

namespace Domain.Interfaces;
public interface IOwnerRepository
{
    void Create(Owner entity);
    List<Owner> GetAll();
    Owner? GetById(int id);
    void UpdateOwner(Owner owner);
    void DeleteOwner(Owner owner);
}