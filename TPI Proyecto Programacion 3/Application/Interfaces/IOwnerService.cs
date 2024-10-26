using Application.Models.OwnerModels;

namespace Application.Interfaces;

public interface IOwnerService
{
    List<OwnerResponse> GetAll();
    OwnerResponse GetById(int id);
    OwnerResponse Create(OwnerRequest owner);
    OwnerResponse UpdateOwner(int id, OwnerRequest owner);
    OwnerResponse DeleteOwner(int id);
    float CalculateOwnerRating(int ownerId);
}
