using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Building
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Ubication { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty; 
        public bool Garage { get; set; }
        public bool BackYard { get; set; }
        public int? Rating { get; set; }
        public ICollection<Appartment>? Appartments { get; set; } 
        public int OwnerId { get; set; } // Foreign Key para el Owner
        public Owner Owner { get; set; }
    }
}
