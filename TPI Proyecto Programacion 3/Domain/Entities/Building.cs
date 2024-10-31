using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Building
    {
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
        public List<Appartment> Appartments { get; set; } = new List<Appartment>();
        [ForeignKey("OwnerId")]
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

    }
}
