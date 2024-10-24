﻿using Application.Models.TenantModels.Request;
using Application.Models.TenantModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Models.Mappings;

public static class TenantProfile
{
    public static Tenant ToTenantEntity(TenantRequest request)
    {
        return new Tenant
        {
            Photo = request.Photo,
        };
    }

    public static TenantResponse ToTenantResponse(Tenant response)
    {
        return new TenantResponse
        {
            Photo = response.Photo,
        };

    }
}