using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.InquilinoModels.Request;
using Contract.InquilinoModels.Response;

namespace Application.Interfaces;

public interface IInquilino
{
    InquilinoResponse Create(InquilinoRequest inquilino);
    List<InquilinoResponse> GetAll();
    InquilinoResponse? GetById(int id);
}

