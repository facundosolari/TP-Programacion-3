﻿using Application.Interfaces;
using Contract.Mappings;
using Contract.BuildingModels.Request;
using Contract.BuildingModels.Response;
using Domain.Interfaces;

namespace Application.Services;

public class BuildingService : IBuilding
{
    private readonly IBuildingRepository _buildingRepository;

    public BuildingService(IBuildingRepository buildingRepository)
    {
        _buildingRepository = buildingRepository;
    }

    public BuildingResponse Create(BuildingRequest building)
    {
        var oBuilding = BuildingsProfile.ToBuildingEntity(building);

        _buildingRepository.Create(oBuilding);

        return BuildingsProfile.ToBuildingResponse(oBuilding);
    }

    public List<BuildingResponse> GetAll()
    {
        var buildings = _buildingRepository.GetAll();
        var buildingsResponse = new List<BuildingResponse>();

        foreach (var building in buildings)
        {
            var buildingResp = BuildingsProfile.ToBuildingResponse(building);

            buildingsResponse.Add(buildingResp);
        }

        return buildingsResponse;
    }

    public BuildingResponse? GetById(int id)
    {
        var building = _buildingRepository.GetById(id);

        if (building is null)
        {
            return null;
        }

        return BuildingsProfile.ToBuildingResponse(building);
    }
}
