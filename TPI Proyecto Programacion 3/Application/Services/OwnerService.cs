using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Contract.Mappings;
using Contract.OwnerModels.Request;
using Contract.OwnerModels.Response;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public OwnerResponse Create(CreateOwnerRequest owner)
        {
            var newOwner = OwnerProfile.ToOwnerEntity(owner);
            _ownerRepository.Create(newOwner);
            return OwnerProfile.ToOwnerResponse(newOwner);
        }

        public List<OwnerResponse> GetAll()
        {
            var owners = _ownerRepository.GetAll();
            var ownersResponse = new List<OwnerResponse>();

            foreach (var owner in owners)
            {
                var ownerResp = OwnerProfile.ToOwnerResponse(owner);
                ownersResponse.Add(ownerResp);
            }

            return ownersResponse;
        }

        public OwnerResponse? GetById(int id)
        {
            var owner = _ownerRepository.GetById(id);

            if (owner == null)
            {
                return null;
            }

            return OwnerProfile.ToOwnerResponse(owner);
        }

        public OwnerResponse? UpdateOwner(int id, UpdateOwnerRequest updatedOwner)
        {
            var owner = _ownerRepository.GetById(id);

            if (owner == null)
            {
                return null;
            }

            OwnerProfile.ToOwnerUpdate(owner, updatedOwner);
            _ownerRepository.UpdateOwner(owner);

            return OwnerProfile.ToOwnerResponse(owner);
        }

        public bool DeleteOwner(int id)
        {
            var owner = _ownerRepository.GetById(id);

            if (owner == null)
            {
                return false;
            }

            _ownerRepository.DeleteOwner(owner);
            return true;
        }
    }
}
