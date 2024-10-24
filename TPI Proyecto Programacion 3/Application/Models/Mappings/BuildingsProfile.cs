using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.BuildingModels.Request;
using Application.Models.BuildingModels.Response;
using Domain.Entities;

namespace Application.Models.Mappings;

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
        };
    }
}