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
            Password = entity.Password,
            Name = entity.Name,
            Lastname = entity.Lastname,
            Email = entity.Email,
        };
    }

    public static void ToAdminUpdate(Admin admin, AdminRequest request)
    {
        admin.Username = request.Username;
        admin.Password = request.Password;
        admin.Name = request.Name;
        admin.Lastname = request.Lastname;
        admin.Email = request.Email;

    }
}
