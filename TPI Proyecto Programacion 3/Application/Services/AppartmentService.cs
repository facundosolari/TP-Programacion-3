using Application.Interfaces;
using Application.Models.Mappings;
using Application.Models.AppartmentModels.Request;
using Application.Models.AppartmentModels.Response;
using Domain.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class AppartmentService : IAppartmentService
    {
        private readonly IAppartmentRepository _appartmentRepository;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IOwnerRepository _ownerRepository;

        public AppartmentService(IAppartmentRepository appartmentRepository, IBuildingRepository buildingRepository, IOwnerRepository ownerRepository)
        {
            _appartmentRepository = appartmentRepository;
            _buildingRepository = buildingRepository;
            _ownerRepository = ownerRepository;
        }

        public List<AppartmentResponse> GetAll()
        {
            var appartments = _appartmentRepository.GetAll();
            var appartmentsResponse = new List<AppartmentResponse>();

            foreach (var appartment in appartments)
            {
                var apparmentResp = AppartmentProfile.ToAppartmentResponse(appartment);

                appartmentsResponse.Add(apparmentResp);
            }

            if (appartments == null || appartments.Count == 0)
            {
                throw new Exception("No existen departamentos");
            }

            var appartmentResponse = appartments.Select(appartment => AppartmentProfile.ToAppartmentResponse(appartment)).ToList();

            return appartmentsResponse;
        }

        public AppartmentResponse? GetById(int id)
        {
            var apparment = _appartmentRepository.GetById(id);

            if (apparment == null)
            {
                throw new Exception("Departamento no encontrado.");
            }

            return AppartmentProfile.ToAppartmentResponse(apparment);
        }

        public AppartmentResponse Create(CreateAppartmentRequest appartment)
        {
            var building = _buildingRepository.GetById(appartment.BuildingId);
            if (building == null) throw new Exception("Building inexistente");
            var newAppartment = AppartmentProfile.ToAppartmentEntity(appartment, building);

            if (newAppartment == null)
            {
                throw new Exception("Ocurrio un error al crear un nuevo departamento.");
            }

            _appartmentRepository.Create(newAppartment);

            return AppartmentProfile.ToAppartmentResponse(newAppartment);
        }

        public AppartmentResponse UpdateAppartment(int id, AppartmentRequest appartment)
        {
            var appartmentEntity = _appartmentRepository.GetById(id);

            if (appartmentEntity == null)
            {

                throw new Exception("Ocurrio un error al obtener el departamento.");
            }

            AppartmentProfile.ToAppartmentEntityUpdate(appartmentEntity, appartment);

            _appartmentRepository.UpdateAppartment(appartmentEntity);

            return AppartmentProfile.ToAppartmentResponse(appartmentEntity);
        }

        public AppartmentResponse DeleteAppartment(int id)
        {
            var appartment = _appartmentRepository.GetById(id);

            if (appartment == null)
            {
                throw new Exception("Ocurrio un error al obtener el departamento.");
                
            }

            _appartmentRepository.DeleteAppartment(appartment);

            return AppartmentProfile.ToAppartmentResponse(appartment);
        }

        public bool AddRating(int id, RatingRequest ratingRequest)
        {
            var appartment = _appartmentRepository.GetById(id);
            if (appartment == null) throw new Exception("Departamento no encontrado");

            if (appartment.TenantId != ratingRequest.TenantId) throw new Exception("No tenés permisos para calificar este departamento.");

            if (!appartment.AddRating(ratingRequest.Rating)) throw new Exception("Calificacion inválida");

            var building = _buildingRepository.GetById(appartment.BuildingId);
            if (building == null) throw new Exception("Edificio no encontrado");
            
            building.UpdateAverageRating();
            _buildingRepository.UpdateBuilding(building);

            var owner = _ownerRepository.GetById(building.OwnerId);
            if (owner == null) throw new Exception("Edificio no encontrado");

            owner.UpdateAverageRating();
            _ownerRepository.UpdateOwner(owner);

            _appartmentRepository.UpdateAppartment(appartment); 
            return true;
        }
    }
}
