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
    BuildingResponse Create(BuildingRequest building);
    List<BuildingResponse> GetAll();
    BuildingResponse? GetById(int id);
}