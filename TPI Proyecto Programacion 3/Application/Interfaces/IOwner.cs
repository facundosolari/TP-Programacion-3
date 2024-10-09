using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.OwnerModels.Request;
using Contract.OwnerModels.Response;

namespace Application.Interfaces;

  public interface IOwnerService
{
    OwnerResponse Create(OwnerRequest owner);
    List<OwnerResponse> GetAll();
    OwnerResponse? GetById(int id);

}
