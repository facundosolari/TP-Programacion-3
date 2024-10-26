using Application.Models.AdminModels;

namespace Application.Interfaces;

public interface IAdminService
{
    List<AdminResponse> GetAll();
    AdminResponse GetById(int id);
    AdminResponse Create(AdminRequest admin);
    AdminResponse UpdateAdmin(int id, AdminRequest admin);
    AdminResponse DeleteAdmin(int id);
   
}
