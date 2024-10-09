using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.BuildingModels.Request;
using Contract.BuildingModels.Response;
using Domain.Enum;

namespace Contract.Mappings;

public static class BuildingsProfile
{
    public static Domain.Entities.Building ToBuildingEntity(BuildingRequest request)
    {
        return new Domain.Entities.Building
        {
            Ubication = request.Ubication,
            Type = request.Type,
            Id = request.Id,
            Adress = request.Adress,
            Bathrooms = request.Bathrooms,
            Rooms = request.Rooms,           //en esto no deja poner los atributos privados del request del mismo
            Garage = request.Garage,
            BackYard = request.BackYard,
            Pictures = request.Pictures,
            Description = request.Description,
            Rating = request.Rating,
            UserId = request.UserId,
        };
    }

    public static BuildingResponse ToBuildingResponse(Domain.Entities.Building response)
    {
        return new BuildingResponse
        {
            Ubication = response.Ubication,
            Type = response.Type,
            Id = response.Id,
            Adress = response.Adress,
            Bathrooms = response.Bathrooms,
            Rooms = response.Rooms,           //en esto no deja poner los atributos privados del request del mismo
            Garage = response.Garage,
            BackYard = response.BackYard,
            Pictures = response.Pictures,
            Description = response.Description,
            Rating = response.Rating,
        };
    }
}