using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Contract.OwnerModels.Response
{
    public class OwnerResponse
    {
        public string? Photo { get; set; }
        public int? Rating { get; set; }
    }
}
