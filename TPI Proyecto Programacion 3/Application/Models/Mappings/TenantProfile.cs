using Domain.Entities;
using Application.Models.TenantModels;

namespace Application.Models.Mappings;

public static class TenantProfile
{
    public static Tenant ToTenantEntity(TenantRequest request)
    {
        return new Tenant
        {
            Username = request.Username,
            Password = request.Password,
            Name = request.Name,
            Lastname = request.Lastname,
            Email = request.Email,
            Photo = request.Photo ?? "https://w7.pngwing.com/pngs/867/694/png-transparent-user-profile-default-computer-icons-network-video-recorder-avatar-cartoon-maker-blue-text-logo.png",
        };
    }

    public static TenantResponse ToTenantResponse(Tenant entity)
    {
        return new TenantResponse
        {
            userId = entity.Id,
            username = entity.Username,
            email = entity.Email,
            firstName = entity.Name,
            lastName = entity.Lastname,
            photo = entity.Photo ?? "https://w7.pngwing.com/pngs/867/694/png-transparent-user-profile-default-computer-icons-network-video-recorder-avatar-cartoon-maker-blue-text-logo.png",
            role = "Tenant",
        };
    }

    public static void ToTenantUpdate(Tenant tenant, TenantRequest request)
    {
        tenant.Username = request.Username;
        tenant.Password = request.Password;
        tenant.Name = request.Name;
        tenant.Lastname = request.Lastname;
        tenant.Email = request.Email;
        tenant.Photo = request.Photo ?? "https://w7.pngwing.com/pngs/867/694/png-transparent-user-profile-default-computer-icons-network-video-recorder-avatar-cartoon-maker-blue-text-logo.png";
    }
}
