using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.BuildingModels.Request;
using Application.Models.BuildingModels.Response;
using Domain.Enum;

namespace Application.Models.Mappings;

public static class BuildingsProfile
{
    public static Domain.Entities.Building ToBuildingEntity(BuildingRequest request)
    {
        return new Domain.Entities.Building
        {
            Ubication = request.Ubication,
            Id = request.Id,
            Adress = request.Adress,         //en esto no deja poner los atributos privados del request del mismo
            Garage = request.Garage,
            BackYard = request.BackYard,
            Rating = request.Rating,
            OwnerId = request.OwnerId,
        };
    }

    public static BuildingResponse ToBuildingResponse(Domain.Entities.Building response)
    {
        return new BuildingResponse
        {
            Ubication = response.Ubication,
            Id = response.Id,
            Adress = response.Adress,           //en esto no deja poner los atributos privados del request del mismo
            Garage = response.Garage,
            BackYard = response.BackYard,
            Rating = response.Rating,
        };
    }
}