using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.TenantModels.Request;
using Application.Models.TenantModels.Response;

namespace Application.Interfaces;

public interface ITenant
{
    TenantResponse Create(TenantRequest tenant);
    List<TenantResponse> GetAll();
    TenantResponse? GetById(int id);
}

