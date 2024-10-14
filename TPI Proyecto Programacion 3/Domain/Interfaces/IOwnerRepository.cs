using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface IOwnerRepository
{
    void Create(Owner entity);
    List<Owner> GetAll();
    Owner? GetById(int id);
}