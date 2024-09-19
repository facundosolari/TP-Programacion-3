using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Inquilino : Usuario
    {
        public string? Foto { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string TipoVivienda { get; set; }
    }
}
