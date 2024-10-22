using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Appartment : Building
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppartmentID { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public int Bathrooms { get; set; }
        public int Rooms { get; set; }
        public List<string> Pictures { get; set; } = new List<string>();
        public string? Description { get; set; }
        public float Price { get; set; }
        public bool isAvailable { get; set; }
        public int BuildingId { get; set; }
        public Tenant? Tenant { get; set; }
    }
}
