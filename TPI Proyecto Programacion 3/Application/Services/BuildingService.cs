using System.Data;
using Application.Interfaces;
using Application.Models.Mappings;
using Application.Models.BuildingModels.Request;
using Application.Models.BuildingModels.Response;
using Domain.Interfaces;

namespace Application.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IAppartmentRepository _appartmentRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly ITenantRepository _tenantRepository;

        public BuildingService(IBuildingRepository buildingRepository, IAppartmentRepository appartmentRepository, IOwnerRepository ownerRepository, ITenantRepository tenantRepository)
        {
            _buildingRepository = buildingRepository;
            _appartmentRepository = appartmentRepository;
            _ownerRepository = ownerRepository;
            _tenantRepository = tenantRepository;
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

            owner.Buildings.Add(newBuilding);

            _buildingRepository.Create(newBuilding);
            _ownerRepository.UpdateOwner(owner);
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

            foreach (var appartment in building.Appartments.ToList())
            {
                if (appartment.TenantId.HasValue) 
                {
                    var tenant = _tenantRepository.GetById(appartment.TenantId.Value); 
                    if (tenant != null)
                    {
                        tenant.AppartmentId = null; 
                        _tenantRepository.UpdateTenant(tenant); 
                    }
                }
                _appartmentRepository.DeleteAppartment(appartment);
            }

            _buildingRepository.DeleteBuilding(building);
            return BuildingsProfile.ToBuildingResponse(building);
        }


    }
}
