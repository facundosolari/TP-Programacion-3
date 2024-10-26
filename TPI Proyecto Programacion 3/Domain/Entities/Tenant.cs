using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Tenant : User
    {
        public string? Photo { get; set; }
        [ForeignKey("AppartmentId")]
        public int? AppartmentId { get; set; } 
        public Appartment? Appartment { get; set; }
    }
}
