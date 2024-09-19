using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Admin : Usuario
    {
        public bool Permisos {  get; set; }  
    }
}
