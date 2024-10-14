using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Data;
public class OwnerRepository : IOwnerRepository
{
    private readonly OwnerDbContext _ownerDbContext;

    public OwnerRepository(OwnerDbContext ownerDbContext)
    {
        _ownerDbContext = ownerDbContext;
    }

    public void Create(Owner entity)
    {
        _ownerDbContext.Owners.Add(entity);
        _ownerDbContext.SaveChanges();
    }

    public List<Owner> GetAll()
    {
        return _ownerDbContext.Owners.ToList();
    }

    public Owner? GetById(int id)
    {
        return _ownerDbContext.Owners.FirstOrDefault(o => o.Id.Equals(id));
    }
}

