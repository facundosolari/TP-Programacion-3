using Application.Models.BuildingModels.Request;
using Application.Models.BuildingModels.Response;
using Domain.Entities;

namespace Application.Models.Mappings;

public static class BuildingsProfile
{
    public static Building ToBuildingEntity(BuildingRequest request, Owner owner)
    {
        return new Building
        {
            Ubication = request.Ubication,
            Address = request.Address,
            Garage = request.Garage,
            BackYard = request.BackYard,
            OwnerId = request.OwnerId,
            Owner = owner,
        };
    }

    public static BuildingResponse ToBuildingResponse(Building response)
    {
        return new BuildingResponse
        {
            Ubication = response.Ubication,
            Address = response.Address,
            Garage = response.Garage,
            BackYard = response.BackYard,
            Id = response.Id,
            OwnerId = response.OwnerId,
        };
    }

    public static void ToBuildingUpdate(Building building, BuildingRequest request)
    {
        building.Ubication = request.Ubication;
        building.Address = request.Address;
        building.Garage = request.Garage;
        building.BackYard = request.BackYard;
    }
}