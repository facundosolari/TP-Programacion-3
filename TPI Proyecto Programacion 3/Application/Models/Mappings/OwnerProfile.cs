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
            Photo = request.Photo,
        };
    }

    public static OwnerResponse ToOwnerResponse(Owner entity)
    {
        return new OwnerResponse
        {
            Username = entity.Username,
            Name = entity.Name,
            Lastname = entity.Lastname,
            Email = entity.Email,
            Photo = entity.Photo ?? "urlDeFotoPredeterminada.com",
        };
    }

    public static void ToOwnerUpdate(Owner owner, OwnerRequest request)
    {
        owner.Username = request.Username;
        owner.Password = request.Password;
        owner.Name = request.Name;
        owner.Lastname = request.Lastname;
        owner.Email = request.Email;
        owner.Photo = request.Photo;
    }
}