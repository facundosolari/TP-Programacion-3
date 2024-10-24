using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Data;
public class AdminRepository : UserRepositoryBase<Admin>, IAdminRepository
{
    public AdminRepository(ProjectContext dbContext) : base(dbContext) { }

    public void Create(Admin entity)
    {
        _dbContext.Admins.Add(entity);
        _dbContext.SaveChanges();
    }

    public List<Admin> GetAll()
    {
        return _dbContext.Admins.ToList();
    }

    public Admin? GetById(int id)
    {
        return _dbContext.Admins.FirstOrDefault(a => a.Id.Equals(id));
    }

    public void UpdateAdmin(Admin entity)
    {
        _dbContext.Admins.Update(entity);
        _dbContext.SaveChanges();
    }

    public void DeleteAdmin(Admin entity)
    {
        _dbContext.Admins.Remove(entity);
        _dbContext.SaveChanges();
    }
}
