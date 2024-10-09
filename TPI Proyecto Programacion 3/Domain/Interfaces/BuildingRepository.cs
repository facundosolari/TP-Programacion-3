using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IBuildingRepository
{
    void Create(Building entity);
    List<Building> GetAll();
    Building? GetById(int id);
}