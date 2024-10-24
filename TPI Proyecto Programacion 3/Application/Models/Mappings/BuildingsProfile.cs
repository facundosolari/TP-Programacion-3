using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.BuildingModels.Request;
using Application.Models.BuildingModels.Response;
using Application.Models.OwnerModels.Request;
using Domain.Entities;

namespace Application.Models.Mappings;

public static class BuildingsProfile
{
    public static Building ToBuildingEntity(BuildingRequest request, Owner owner)
    {
        return new Building
        {
            Ubication = request.Ubication,
            Adress = request.Adress,
            Garage = request.Garage,
            BackYard = request.BackYard,
            Rating = request.Rating,
            OwnerId = request.OwnerId,
            Owner = owner,
        };
    }

    public static BuildingResponse ToBuildingResponse(Building response)
    {
        return new BuildingResponse
        {
            Ubication = response.Ubication,
            Adress = response.Adress,
            Garage = response.Garage,
            BackYard = response.BackYard,
            Rating = response.Rating,
        };
    }

    public static void ToBuildingUpdate(Building building, BuildingRequest request)
    {
        building.Ubication = request.Ubication;
        building.Adress = request.Adress;
        building.Garage = request.Garage;
        building.BackYard = request.BackYard;
        building.Rating = request.Rating;
    }
}