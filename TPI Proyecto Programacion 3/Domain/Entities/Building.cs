using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Building
    {
        private int _ratingSum = 0;
        private int _ratingCount = 0;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Ubication { get; set; } 
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Adress { get; set; } 
        [Required]
        public bool Garage { get; set; }
        [Required]
        public bool BackYard { get; set; }
        public float Rating { get; set; } = 0;
        public List<Appartment>? Appartments { get; set; }
        [ForeignKey("OwnerId")]
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }


        public void UpdateAverageRating()
        {
            if (Appartments == null)
            {
                Rating = 0; 
                return;
            }

            Rating = Appartments.Sum(a => a.Rating) / Appartments.Count; 
        }
    }
}
