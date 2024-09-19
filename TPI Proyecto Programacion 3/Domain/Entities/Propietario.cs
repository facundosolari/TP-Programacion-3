using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Propietario : Usuario
    {
        public List<Inmueble> Propiedades {  get; set; } = new List<Inmueble>();
        public string? Foto { get; set; }
        public int? Rating {  get; set; }  
    }
}
