using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.TenantModels.Request;
using Contract.TenantModels.Response;

namespace Application.Interfaces;

public interface ITenant
{
    TenantResponse Create(TenantRequest tenant);
    List<TenantResponse> GetAll();
    TenantResponse? GetById(int id);
}

