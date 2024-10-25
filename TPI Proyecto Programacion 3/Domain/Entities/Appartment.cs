using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Appartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? TenantId { get; set; } // Foreign Key para el Tenant
        public Tenant? Tenant { get; set; }
        public int? BuildingId { get; set; } // Foreign Key para el Building
        public Building? Building { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public int Bathrooms { get; set; }
        public int Rooms { get; set; }
        public List<string> Pictures { get; set; } = new List<string>();
        public string Description { get; set; } = string.Empty; 
        public float Price { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
