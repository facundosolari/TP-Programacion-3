using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Contract.TenantModels.Request
{
    public class TenantRequest
    {
        public int Id { get; set; }
        public string? Photo { get; set; }
    }
}
