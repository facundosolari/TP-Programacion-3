using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Models.TenantModels.Response;
using Application.Models.TenantModels.Request;

namespace Application.Models.Mappings;

public static class TenantProfile
{
    public static Tenant ToTenantEntity(CreateTenantRequest request)
    {
        return new Tenant
        {
            Username = request.Username,
            Password = request.Password,
            Name = request.Name,
            Lastname = request.Lastname,
            Email = request.Email,
            Photo = request.Photo,
        };
    }

    public static TenantResponse ToTenantResponse(Tenant entity)
    {
        return new TenantResponse
        {
            Username = entity.Username,
            Name = entity.Name,
            Lastname = entity.Lastname,
            Email = entity.Email,
            Photo = entity.Photo ?? "urlDeFotoPredeterminada.com",
        };
    }

    public static CreateTenantRequest ToUpdateTenantRequest(Tenant entity)
    {
        return new CreateTenantRequest
        {
            Username = entity.Username,
            Password = entity.Password,
            Name = entity.Name,
            Lastname = entity.Lastname,
            Email = entity.Email,
            Photo = entity.Photo,
        };
    }

    public static void ToTenantUpdate(Tenant tenant, CreateTenantRequest request)
    {
        tenant.Username = request.Username;
        tenant.Password = request.Password;
        tenant.Name = request.Name;
        tenant.Lastname = request.Lastname;
        tenant.Email = request.Email;
        tenant.Photo = request.Photo;
    }
}
