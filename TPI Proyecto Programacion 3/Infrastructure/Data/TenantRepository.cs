using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Data;

public class TenantRepository : ITenantRepository
{
    private readonly ProjectContext _dbContext;

    public TenantRepository(ProjectContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(Tenant entity)
    {
        _dbContext.Tenants.Add(entity);
        _dbContext.SaveChanges();
    }

    public List<Tenant> GetAll()
    {
        return _dbContext.Tenants.ToList();
    }

    public Tenant? GetById(int id)
    {
        return _dbContext.Tenants.FirstOrDefault(m => m.Id.Equals(id));
    }
    public void UpdateTenant(Tenant entity)
    {
        _dbContext.Tenants.Update(entity);
        _dbContext.SaveChanges();
    }

    public void DeleteTenant(Tenant entity)
    {
        _dbContext.Tenants.Remove(entity);
        _dbContext.SaveChanges();
    }
}
