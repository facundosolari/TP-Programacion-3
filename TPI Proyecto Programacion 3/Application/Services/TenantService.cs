using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models.Mappings;
using Application.Models.TenantModels.Request;
using Application.Models.TenantModels.Response;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IAppartmentRepository _appartmentRepository;

        public TenantService(ITenantRepository tenantRepository, IAppartmentRepository appartmentRepository)
        {
            _tenantRepository = tenantRepository;
            _appartmentRepository = appartmentRepository;
        }

        public List<TenantResponse> GetAll()
        {
            var tenants = _tenantRepository.GetAll();

            if (tenants == null || tenants.Count == 0)
            {
                throw new Exception("No existen inquilinos");
            }

            var tenantsResponse = tenants.Select(tenant => TenantProfile.ToTenantResponse(tenant)).ToList();

            return tenantsResponse;
        }

        public TenantResponse GetById(int id)
        {
            var tenant = _tenantRepository.GetById(id);

            if (tenant == null)
            {
                throw new Exception("Inquilino no encontrado");
            }

            return TenantProfile.ToTenantResponse(tenant);
        }

        public TenantResponse Create(CreateTenantRequest tenant)
        {
            var newTenant = TenantProfile.ToTenantEntity(tenant);

            if (newTenant == null)
            {
                throw new Exception("Error al crear nuevo inquilino");
            }

            _tenantRepository.Create(newTenant);
            return TenantProfile.ToTenantResponse(newTenant);
        }

        public TenantResponse UpdateTenant(int id, CreateTenantRequest updatedTenant)
        {
            var tenant = _tenantRepository.GetById(id);

            if (tenant == null)
            {
                throw new Exception("Inquilino no encontrado");
            }

            TenantProfile.ToTenantUpdate(tenant, updatedTenant);
            _tenantRepository.UpdateTenant(tenant);

            return TenantProfile.ToTenantResponse(tenant);
        }

        public TenantResponse DeleteTenant(int id)
        {
            var tenant = _tenantRepository.GetById(id);

            if (tenant == null)
            {
                throw new Exception("Inquilino no encontrado");
            }

            _tenantRepository.DeleteTenant(tenant);
            return TenantProfile.ToTenantResponse(tenant);
        }

        public bool AssignAppartmentToTenant(int tenantId, int appartmentId)
        {
            var tenant = _tenantRepository.GetById(tenantId);
            if (tenant == null)
            {
                throw new Exception("Inquilino no encontrado");
            }

            var appartment = _appartmentRepository.GetById(appartmentId);
            if (appartment == null)
            {
                throw new Exception("Apartamento no encontrado");
            }

            if (tenantId == appartment.TenantId || appartmentId == tenant.AppartmentId) 
            {
                tenant.Appartment = null;
                tenant.AppartmentId = null;
                _appartmentRepository.UpdateAppartment(appartment);

                appartment.Tenant = null;
                appartment.TenantId = null;
                _tenantRepository.UpdateTenant(tenant);

                throw new Exception("Desasignacion completada");
            }

            if (!appartment.IsAvailable)
            {
                throw new Exception("Apartamento no disponible");
            }

            tenant.Appartment = appartment;
            _tenantRepository.UpdateTenant(tenant);

            appartment.IsAvailable = false;
            appartment.Tenant = tenant;
            _appartmentRepository.UpdateAppartment(appartment);

            return true;
        }
    }
}
