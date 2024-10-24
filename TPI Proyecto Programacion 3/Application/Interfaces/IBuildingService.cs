using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.BuildingModels.Request;
using Application.Models.BuildingModels.Response;

namespace Application.Interfaces;

public interface IBuildingService
{
    List<BuildingResponse> GetAll();
    BuildingResponse? GetById(int id);
    BuildingResponse Create(BuildingRequest building);
    BuildingResponse UpdateBuilding(int id, BuildingRequest building);
    BuildingResponse DeleteBuilding(int id);
    bool AssignAppartmentToBuilding(int buildingId, int appartmentId);
}