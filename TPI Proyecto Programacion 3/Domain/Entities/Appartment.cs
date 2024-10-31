using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Appartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("TenantId")]
        public int? TenantId { get; set; } 
        public Tenant? Tenant { get; set; }
        [ForeignKey("BuildingId")]
        public int BuildingId { get; set; } 
        public Building Building { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int Bathrooms { get; set; }
        [Required]
        public int Rooms { get; set; }
        [Required]
        public List<string> Pictures { get; set; } = new List<string>();
        public string Description { get; set; } = string.Empty;
        [Required]
        public float Price { get; set; }
        public bool IsAvailable { get; set; } = true;
        public List<Rating> Ratings { get; set; } = new List<Rating>(); 
        public float Rating { get; set; }

        public bool AddRating(Rating rating)
        {
            Ratings.Add(rating);
            return true;
        }
    }
}
