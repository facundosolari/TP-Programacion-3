using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tenant : User
    {
        public string? Picture { get; set; }
        public string? Adress { get; set; }
        public string? TypeBuilding { get; set; }
    }
}
