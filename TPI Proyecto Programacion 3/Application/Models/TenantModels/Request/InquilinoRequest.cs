using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Models.TenantModels.Request
{
    public class TenantRequest
    {
        public string? Picture { get; set; }
        public string? Adress { get; set; }
        public string? TypeBuilding { get; set; }
    }
}
