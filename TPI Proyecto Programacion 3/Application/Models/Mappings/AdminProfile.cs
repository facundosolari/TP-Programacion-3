using Domain.Entities;
using Application.Models.AdminModels.Request;
using Application.Models.AdminModels.Response;

namespace Application.Models.Mappings;

public static class AdminProfile
{
    public static Admin ToAdminEntity(AdminRequest request)
    {
        return new Admin
        {
            Username = request.Username,
            Name = request.Name,
            Lastname = request.Lastname,
            Email = request.Email,
        };
    }

    public static AdminResponse ToAdminResponse(Admin entity)
    {
        return new AdminResponse
        {
            Username = entity.Username,
            Name = entity.Name,
            Lastname = entity.Lastname,
            Email = entity.Email,
        };
    }

    public static AdminRequest ToUpdateAdminRequest(Admin entity)
    {
        return new AdminRequest
        {
            Username = entity.Username,
            Name = entity.Name,
            Lastname = entity.Lastname,
            Email = entity.Email,
        };
    }

    public static void ToAdminUpdate(Admin admin, AdminRequest request)
    {
        admin.Username = request.Username;
        admin.Name = request.Name;
        admin.Lastname = request.Lastname;
        admin.Email = request.Email;

    }
}
