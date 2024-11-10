using Domain.Entities;
using Application.Models.OwnerModels;

namespace Application.Models.Mappings;

public static class OwnerProfile
{
    public static Owner ToOwnerEntity(OwnerRequest request)
    {
        return new Owner
        {
            Username = request.Username,
            Password = request.Password,
            Name = request.Name,
            Lastname = request.Lastname,
            Email = request.Email,
            Photo = request.Photo ?? "https://w7.pngwing.com/pngs/867/694/png-transparent-user-profile-default-computer-icons-network-video-recorder-avatar-cartoon-maker-blue-text-logo.png",
        };
    }

    public static OwnerResponse ToOwnerResponse(Owner entity)
    {
        return new OwnerResponse
        {
            userId = entity.Id,
            username = entity.Username,
            email = entity.Email,
            firstName = entity.Name,
            lastName = entity.Lastname,
            photo = entity.Photo ?? "https://w7.pngwing.com/pngs/867/694/png-transparent-user-profile-default-computer-icons-network-video-recorder-avatar-cartoon-maker-blue-text-logo.png",
            role = "Owner",
        };
    }

    public static void ToOwnerUpdate(Owner owner, OwnerRequest request)
    {
        owner.Username = request.Username;
        owner.Password = request.Password;
        owner.Name = request.Name;
        owner.Lastname = request.Lastname;
        owner.Email = request.Email;
        owner.Photo = request.Photo ?? "https://w7.pngwing.com/pngs/867/694/png-transparent-user-profile-default-computer-icons-network-video-recorder-avatar-cartoon-maker-blue-text-logo.png";
    }
}