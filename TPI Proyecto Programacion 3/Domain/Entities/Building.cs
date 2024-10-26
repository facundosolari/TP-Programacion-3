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
        private int _ratingSum = 0;
        private int _ratingCount = 0;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Ubication { get; set; } = string.Empty;
        [Required]
        public string Adress { get; set; } = string.Empty; 
        [Required]
        public bool Garage { get; set; }
        [Required]
        public bool BackYard { get; set; }
        public float Rating { get; set; } = 0;
        public ICollection<Appartment>? Appartments { get; set; }
        [Required]
        public int OwnerId { get; set; } // Foreign Key para el Owner
        [Required]
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
