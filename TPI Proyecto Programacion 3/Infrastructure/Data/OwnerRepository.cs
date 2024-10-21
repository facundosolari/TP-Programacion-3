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
    private readonly ProjectContext _dbContext;

    public OwnerRepository(ProjectContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(Owner entity)
    {
        _dbContext.Owners.Add(entity);
        _dbContext.SaveChanges();
    }

    public List<Owner> GetAll()
    {
        return _dbContext.Owners.ToList();
    }

    public Owner? GetById(int id)
    {
        return _dbContext.Owners.FirstOrDefault(o => o.Id.Equals(id));
    }

    public void UpdateOwner(Owner entity)
    {
        _dbContext.Owners.Update(entity);
        _dbContext.SaveChanges();
    }

    public void DeleteOwner(Owner entity)
    {
        _dbContext.Owners.Remove(entity);
        _dbContext.SaveChanges();
    }
}

