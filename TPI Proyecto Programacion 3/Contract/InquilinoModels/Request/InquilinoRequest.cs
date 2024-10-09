using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Contract.InquilinoModels.Request
{
    public class InquilinoRequest
    {
        public string? Picture { get; set; }
        public string? Adress { get; set; }
        public string? TypeBuilding { get; set; }
    }
}
