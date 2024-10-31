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
        private readonly ITenantRepository _tenantRepository;

        public AppartmentService(IAppartmentRepository appartmentRepository, IBuildingRepository buildingRepository, IOwnerRepository ownerRepository, ITenantRepository tenantRepository)
        {
            _appartmentRepository = appartmentRepository;
            _buildingRepository = buildingRepository;
            _ownerRepository = ownerRepository;
            _tenantRepository = tenantRepository;
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

        public AppartmentResponse Create(AppartmentRequest appartment)
        {
            var building = _buildingRepository.GetById(appartment.BuildingId);
            if (building == null) throw new Exception("Building inexistente");
            var newAppartment = AppartmentProfile.ToAppartmentEntity(appartment, building);

            if (newAppartment == null)
            {
                throw new Exception("Ocurrio un error al crear un nuevo departamento.");
            }

            building.Appartments.Add(newAppartment);

            _appartmentRepository.Create(newAppartment);
            _buildingRepository.UpdateBuilding(building);

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

            var tenant = _tenantRepository.GetById(id);
            if (tenant != null)
            {
                tenant.AppartmentId = null;
                _tenantRepository.UpdateTenant(tenant);
            }

            _appartmentRepository.DeleteAppartment(appartment);

            return AppartmentProfile.ToAppartmentResponse(appartment);
        }

        public bool AddRating(RatingRequest ratingRequest)
        {
            var appartment = _appartmentRepository.GetById(ratingRequest.AppartmentId);
            if (appartment == null) throw new Exception("Departamento no encontrado");

            if (appartment.TenantId != ratingRequest.TenantId) throw new Exception("No tenés permisos para calificar este departamento.");

            var tenant = _tenantRepository.GetById(ratingRequest.TenantId);
            if (tenant == null) throw new Exception("Inquilino no encontrado");

            var rating = AppartmentProfile.ToRatingEntity(ratingRequest, appartment, tenant);

            if (ratingRequest.Value < 1 || ratingRequest.Value > 5) throw new Exception("Rating invalido");
            
            appartment.Ratings.Add(rating);
            _appartmentRepository.UpdateAppartment(appartment);


            var ratings = _appartmentRepository.GetRatingsByAppartmentId(appartment.Id);
            if (ratings.Any())
            {
                appartment.Rating = (float)Math.Round(ratings.Average(r => r.Value), 1, MidpointRounding.ToEven);
            }
            else
            {
                appartment.Rating = 0; 
            }

            _appartmentRepository.UpdateAppartment(appartment);
            return true;
        }
    }
}
