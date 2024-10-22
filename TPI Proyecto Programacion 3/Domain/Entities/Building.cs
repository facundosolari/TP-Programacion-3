using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enum;

namespace Domain.Entities
{
    public class Building
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuildingId { get; set; }
        public string Ubication { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty; 
        public bool Garage { get; set; }
        public bool BackYard { get; set; }
        public int? Rating { get; set; }
        public List<Appartment> Appartments { get; set; } = new List<Appartment>();
        public Owner Owner { get; set; } = new Owner();
    }
}
