using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.OwnerModels.Request
{
    public class OwnerRequest
    {
        public List<Building> Property { get; set; } = new List<Building>();
        public string? Photo { get; set; }
        public int? Rating { get; set; }
    }
}
