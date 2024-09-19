using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class Usuario
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public bool Permisos { get; set; } = false;
    }
}
