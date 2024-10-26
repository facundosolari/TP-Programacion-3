using System.ComponentModel.DataAnnotations;

namespace Application.Models.AppartmentModels.Request
{
    public class AppartmentRequest
    {
        [Required]
        public int Floor { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int Bathrooms { get; set; }
        [Required]
        public int Rooms { get; set; }
        public List<string> Pictures { get; set; } = new List<string>();
        public string Description { get; set; } = string.Empty;
        [Required]
        public float Price { get; set; }
        public int BuildingId { get; set; }
    }
}