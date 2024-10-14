﻿using Application.Interfaces;
using Contract.Mappings;
using Contract.AppartmentModels.Request;
using Contract.AppartmentModels.Response;
using Domain.Interfaces;

namespace Application.Services
{
    public class AppartmentService : IAppartmentService
    {
        private readonly IAppartmentRepository _appartmentRepository;

        public AppartmentService(IAppartmentRepository appartmentRepository)
        {
            _appartmentRepository = appartmentRepository;
        }

        public AppartmentResponse Create(AppartmentRequest appartment)
        {
            var oAppartment = AppartmentProfile.ToAppartmentEntity(appartment);

            _appartmentRepository.Create(oAppartment);

            return AppartmentProfile.ToApparmentResponse(oAppartment);
        }

        public List<AppartmentResponse> GetAll()
        {
            var appartments = _appartmentRepository.GetAll();
            var appartmentsResponse = new List<AppartmentResponse>();

            foreach (var appartment in appartments)
            {
                var apparmentResp = AppartmentProfile.ToApparmentResponse(appartment);

                appartmentsResponse.Add(apparmentResp);
            }

            return appartmentsResponse;
        }

        public AppartmentResponse? GetById(int id)
        {
            var apparment = _appartmentRepository.GetById(id);

            if (apparment is null)
            {
                return null;
            }

            return AppartmentProfile.ToApparmentResponse(apparment);
        }
    }
}
