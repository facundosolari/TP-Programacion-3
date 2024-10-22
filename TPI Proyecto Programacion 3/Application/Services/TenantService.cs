using Application.Interfaces;
using Contract.TenantModels.Request;
using Contract.TenantModels.Response;
using Contract.Mappings;
using Domain.Interfaces;

namespace Application.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public TenantResponse Create(TenantRequest tenant)
        {
            var oTenant = TenantProfile.ToTenantEntity(tenant);

            _tenantRepository.Create(oTenant);

            return TenantProfile.ToTenantResponse(oTenant);
        }

        public List<TenantResponse> GetAll()
        {
            var tenants = _tenantRepository.GetAll();
            var tenantsResponse = new List<TenantResponse>();

            foreach (var tenant in tenants)
            {
                var tenantResp = TenantProfile.ToTenantResponse(tenant);
                tenantsResponse.Add(tenantResp);
            }
            return tenantsResponse;
        }

        public TenantResponse? GetById(int id)
        {
            var tenant = _tenantRepository.GetById(id);

            if (tenant is null)
            {
                return null;
            }
            return TenantProfile.ToTenantResponse(tenant);
        }
    }
}
