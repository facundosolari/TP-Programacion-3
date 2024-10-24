using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.OwnerModels.Request;
using Application.Models.OwnerModels.Response;

namespace Application.Interfaces;

public interface IOwnerService
{
    List<OwnerResponse> GetAll();
    OwnerResponse GetById(int id);
    OwnerResponse Create(CreateOwnerRequest owner);
    OwnerResponse UpdateOwner(int id, UpdateOwnerRequest owner);
    OwnerResponse DeleteOwner(int id);
    bool AssignBuildingToOwner(int ownerId, int buildingId);
}
