using Domain.Entities;
using Application.Models.AdminModels;

namespace Application.Models.Mappings;

public static class AdminProfile
{
    public static Admin ToAdminEntity(AdminRequest request)
    {
        return new Admin
        {
            Username = request.Username,
            Password = request.Password,
            Name = request.Name,
            Lastname = request.Lastname,
            Email = request.Email,
            Photo = "https://w7.pngwing.com/pngs/867/694/png-transparent-user-profile-default-computer-icons-network-video-recorder-avatar-cartoon-maker-blue-text-logo.png"
        };
    }

    public static AdminResponse ToAdminResponse(Admin entity)
    {
        return new AdminResponse
        {
            userId = entity.Id,
            username = entity.Username,
            email = entity.Email,
            firstName = entity.Name,
            lastName = entity.Lastname,
            photo = "https://w7.pngwing.com/pngs/867/694/png-transparent-user-profile-default-computer-icons-network-video-recorder-avatar-cartoon-maker-blue-text-logo.png",
            role = "Admin",
        };
    }

    public static void ToAdminUpdate(Admin admin, AdminRequest request)
    {
        admin.Username = request.Username;
        admin.Password = request.Password;
        admin.Name = request.Name;
        admin.Lastname = request.Lastname;
        admin.Email = request.Email;
        admin.Photo = "https://w7.pngwing.com/pngs/867/694/png-transparent-user-profile-default-computer-icons-network-video-recorder-avatar-cartoon-maker-blue-text-logo.png";
    }
}
