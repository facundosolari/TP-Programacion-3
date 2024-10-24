using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models.Mappings;
using Application.Models.BuildingModels.Request;
using Application.Models.BuildingModels.Response;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IAppartmentRepository _appartmentRepository;
        private readonly IOwnerRepository _ownerRepository;

        public BuildingService(IBuildingRepository buildingRepository, IAppartmentRepository appartmentRepository, IOwnerRepository ownerRepository)
        {
            _buildingRepository = buildingRepository;
            _appartmentRepository = appartmentRepository;
            _ownerRepository = ownerRepository;
        }

        public List<BuildingResponse> GetAll()
        {
            var buildings = _buildingRepository.GetAll();

            if (buildings == null || buildings.Count == 0)
            {
                throw new Exception("No existen edificios");
            }

            var buildingsResponse = buildings.Select(building => BuildingsProfile.ToBuildingResponse(building)).ToList();

            return buildingsResponse;
        }

        public BuildingResponse GetById(int id)
        {
            var building = _buildingRepository.GetById(id);

            if (building == null)
            {
                throw new Exception("Edificio no encontrado");
            }

            return BuildingsProfile.ToBuildingResponse(building);
        }

        public BuildingResponse Create(BuildingRequest building)
        {
            var owner = _ownerRepository.GetById(building.OwnerId);
            if (owner == null) throw new Exception("Owner inexistente");
            var newBuilding = BuildingsProfile.ToBuildingEntity(building, owner);

            if (newBuilding == null)
            {
                throw new Exception("Error al crear nuevo edificio");
            }

            _buildingRepository.Create(newBuilding);
            return BuildingsProfile.ToBuildingResponse(newBuilding);
        }

        public BuildingResponse UpdateBuilding(int id, BuildingRequest updatedBuilding)
        {
            var building = _buildingRepository.GetById(id);

            if (building == null)
            {
                throw new Exception("Edificio no encontrado");
            }

            BuildingsProfile.ToBuildingUpdate(building, updatedBuilding);
            _buildingRepository.UpdateBuilding(building);

            return BuildingsProfile.ToBuildingResponse(building);
        }

        public BuildingResponse DeleteBuilding(int id)
        {
            var building = _buildingRepository.GetById(id);

            if (building == null)
            {
                throw new Exception("Edificio no encontrado");
            }

            _buildingRepository.DeleteBuilding(building);
            return BuildingsProfile.ToBuildingResponse(building);
        }

        public bool AssignAppartmentToBuilding(int buildingId, int appartmentId)
        {
            var building = _buildingRepository.GetById(buildingId);
            if (building == null)
            {
                throw new Exception("Edificio no encontrado");
            }

            var appartment = _appartmentRepository.GetById(appartmentId);
            if (appartment == null)
            {
                throw new Exception("Apartamento no encontrado");
            }

            if (building.Appartments == null)
            {
                building.Appartments = new List<Appartment>();
            }
            building.Appartments.Add(appartment);

            _buildingRepository.UpdateBuilding(building);

            return true;
        }
    }
}
