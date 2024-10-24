using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITenantRepository
    {
        void Create(Tenant entity);
        List<Tenant> GetAll();
        Tenant? GetById(int id);
        void UpdateTenant(Tenant tenant);
        void DeleteTenant(Tenant tenant);
    }
}
