using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Inmueble
    {
        private string Ubicacion {  get; set; }
        private string Tipo { get; set; }
        public string Localidad { get; set; }
        private int ID { get; set; }
        public string Direccion { get; set; }
        public int Baños { get; set; }
        public int Ambientes { get; set; }
        public bool Garage { get; set; }
        public bool Patio {  get; set; }
        public List<string>? Fotos {  get; set; } = new List<string>();
        public string? Descripcion {  get; set; }
        public int? Rating { get; set; }
        public bool Habilitacion { get; set; } = false;
    }
}
