using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.TenantModels.Request;
using Application.Models.TenantModels.Response;

namespace Application.Interfaces;

public interface ITenantService
{
    List<TenantResponse> GetAll();
    TenantResponse GetById(int id);
    TenantResponse Create(CreateTenantRequest tenant);
    TenantResponse UpdateTenant(int id, CreateTenantRequest tenant);
    TenantResponse DeleteTenant(int id);
    bool AssignAppartmentToTenant(int tenantId, int appartmentId);
}
