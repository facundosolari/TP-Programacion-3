using Application.Models.TenantModels;

namespace Application.Interfaces;

public interface ITenantService
{
    List<TenantResponse> GetAll();
    TenantResponse GetById(int id);
    TenantResponse Create(TenantRequest tenant);
    TenantResponse UpdateTenant(int id, TenantRequest tenant);
    TenantResponse DeleteTenant(int id);
    bool AssignAppartmentToTenant(int tenantId, int appartmentId);
}
