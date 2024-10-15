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
}