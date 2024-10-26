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
        [Required]
        public int BuildingId { get; set; } // Foreign Key para el Building
        [Required]
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
        public float Rating { get; set; } = 0;

        private int _ratingCount = 0;
        private int _ratingSum = 0;


        public bool AddRating(int rating)
        {
            if (rating < 1 || rating > 5) return false;

            _ratingSum += rating; 
            _ratingCount++;

            Rating = _ratingCount == 0 ? 0 : (float)_ratingSum / _ratingCount;

            return true;
        }
    }
}
