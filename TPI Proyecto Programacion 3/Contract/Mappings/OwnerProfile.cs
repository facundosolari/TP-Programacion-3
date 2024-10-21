using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enum;
using Domain.Entities;
using Contract.OwnerModels.Response;
using Contract.OwnerModels.Request;

namespace Contract.Mappings;

public static class OwnerProfile
{
    public static Owner ToOwnerEntity(CreateOwnerRequest request)
    {
        return new Owner
        {
            Username = request.Username,
            Password = request.Password,
            Name = request.Name,
            Lastname = request.Lastname,
            Email = request.Email,
        };
    }

    public static OwnerResponse ToOwnerResponse(Owner entity)
    {
        return new OwnerResponse
        {
            Username = entity.Username,
            Password = entity.Password,
            Name = entity.Name,
            Lastname = entity.Lastname,
            Email = entity.Email,
        };
    }

    public static UpdateOwnerRequest ToUpdateOwnerRequest(Owner entity)
    {
        return new UpdateOwnerRequest
        {
            Username = entity.Username,
            Password = entity.Password,
            Name = entity.Name,
            Lastname = entity.Lastname,
            Email = entity.Email,
            Property = entity.Property,
            Photo = entity.Photo,
            Rating = entity.Rating,
        };
    }

    public static void ToOwnerUpdate(Owner owner, UpdateOwnerRequest request)
    {
        owner.Username = request.Username;
        owner.Password = request.Password;
        owner.Name = request.Name;
        owner.Lastname = request.Lastname;
        owner.Email = request.Email;
        owner.Property = request.Property;
        owner.Photo = request.Photo;
        owner.Rating = request.Rating;
    }
}