using Domain.Entities;

namespace Domain.Interfaces;

public interface IAdminRepository
{
    void Create(Admin entity);
    List<Admin> GetAll();
    Admin? GetById(int id);
    void UpdateAdmin(Admin admin);
    void DeleteAdmin(Admin admin);
}