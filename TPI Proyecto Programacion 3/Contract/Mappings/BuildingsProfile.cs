using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.BuildingModels.Request;
using Contract.BuildingModels.Response;
using Domain.Enum;
using Domain.Entities;

namespace Contract.Mappings;

public static class BuildingsProfile
{
    public static Building ToBuildingEntity(BuildingRequest request)
    {
        return new Building
        {
            BuildingId = request.BuildingId,
            Ubication = request.Ubication,
            Adress = request.Adress,
            Garage = request.Garage,
            BackYard = request.BackYard,
            Rating = request.Rating,
            Appartments = request.Appartments,
            Owner = request.Owner,
        };
    }

    public static BuildingResponse ToBuildingResponse(Building response)
    {
        return new BuildingResponse
        {
            BuildingId = response.BuildingId,
            Ubication = response.Ubication,
            Adress = response.Adress,
            Garage = response.Garage,
            BackYard = response.BackYard,
            Rating = response.Rating,
            Appartments = response.Appartments,
            Owner = response.Owner,
        };
    }
}