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

        public AppartmentService(IAppartmentRepository appartmentRepository)
        {
            _appartmentRepository = appartmentRepository;
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

            var ownersResponse = appartments.Select(appartment => AppartmentProfile.ToAppartmentResponse(appartment)).ToList();

            return appartmentsResponse;
        }

        public AppartmentResponse? GetById(int id)
        {
            var apparment = _appartmentRepository.GetById(id);

            if (apparment is null)
            {
                return null;
            }

            return AppartmentProfile.ToAppartmentResponse(apparment);
        }

        public AppartmentResponse Create(AppartmentRequest appartment)
        {
            var oAppartment = AppartmentProfile.ToAppartmentEntity(appartment);

            _appartmentRepository.Create(oAppartment);

            return AppartmentProfile.ToAppartmentResponse(oAppartment);
        }

        public bool UpdateAppartment(int id, AppartmentRequest appartment)
        {
            var appartmentEntity = _appartmentRepository.GetById(id);

            if (appartmentEntity != null)
            {
                AppartmentProfile.ToAppartmentEntityUpdate(appartmentEntity, appartment);
                
                _appartmentRepository.UpdateAppartment(appartmentEntity);

                return true;
            }
            return false;
        }

        public bool DeleteAppartment(int id)
        {
            var appartment = _appartmentRepository.GetById(id);

            if (appartment != null)
            {
                _appartmentRepository.DeleteAppartment(appartment);

                return true;
            }

            return false;
        }
    }
}
