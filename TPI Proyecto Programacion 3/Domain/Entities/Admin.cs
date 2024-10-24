using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Admin : User
    {
        public override bool IsAdmin { get; set; } = true; // ? ver de que manera manejarlo
    }
}
