﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models.Mappings;
using Application.Models.OwnerModels.Request;
using Application.Models.OwnerModels.Response;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IBuildingRepository _buildingRepository;

        public OwnerService(IOwnerRepository ownerRepository, IBuildingRepository buildingRepository, IAppartmentRepository appartmentRepository)
        {
            _ownerRepository = ownerRepository;
            _buildingRepository = buildingRepository;
        }

        public List<OwnerResponse> GetAll()
        {
            var owners = _ownerRepository.GetAll();

            if (owners == null || owners.Count == 0)
            {
                throw new Exception("No existen propietarios");
            }

            var ownersResponse = owners.Select(owner => OwnerProfile.ToOwnerResponse(owner)).ToList();

            return ownersResponse;
        }

        public OwnerResponse GetById(int id)
        {
            var owner = _ownerRepository.GetById(id);

            if (owner == null)
            {
                throw new Exception("Propietario no encontrado");
            }

            return OwnerProfile.ToOwnerResponse(owner);
        }

        public OwnerResponse Create(CreateOwnerRequest owner)
        {
            var newOwner = OwnerProfile.ToOwnerEntity(owner);

            if (newOwner == null)
            {
                throw new Exception("Error al crear nuevo propietario");
            }

            _ownerRepository.Create(newOwner);
            return OwnerProfile.ToOwnerResponse(newOwner);
        }

        public OwnerResponse UpdateOwner(int id, UpdateOwnerRequest updatedOwner)
        {
            var owner = _ownerRepository.GetById(id);

            if (owner == null)
            {
                throw new Exception("Propietario no encontrado");
            }

            OwnerProfile.ToOwnerUpdate(owner, updatedOwner);
            _ownerRepository.UpdateOwner(owner);

            return OwnerProfile.ToOwnerResponse(owner);
        }

        public OwnerResponse DeleteOwner(int id)
        {
            var owner = _ownerRepository.GetById(id);

            if (owner == null)
            {
                throw new Exception("Propietario no encontrado");
            }

            _ownerRepository.DeleteOwner(owner);
            return OwnerProfile.ToOwnerResponse(owner);
        }

        public float CalculateOwnerRating(int ownerId)
        {
            var owner = _ownerRepository.GetById(ownerId);
            if (owner == null) throw new Exception("Propietario no encontrado");

            var buildings = _buildingRepository.GetAll()
                .Where(b => b.OwnerId == ownerId)
                .ToList();

            if (buildings.Count == 0) return 0;

            var totalRating = buildings.Sum(b => b.Rating);

            float averageRating = totalRating / buildings.Count;


            return (float)Math.Round(averageRating, 1);
        }
    }
}
