using Application.Interfaces;
using Contract.Mappings;
using Contract.AppartmentModels.Request;
using Contract.AppartmentModels.Response;
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
            var oAppartment = AppartmentProfile.ToAppartmentEntity(appartment);

            if (oAppartment == null)
            {
                throw new Exception("Ocurrio un error al crear un nuevo departamento.");
            }

            _appartmentRepository.Create(oAppartment);

            return AppartmentProfile.ToAppartmentResponse(oAppartment);
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
    }
}
