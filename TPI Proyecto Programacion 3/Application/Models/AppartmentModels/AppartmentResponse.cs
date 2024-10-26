using System.ComponentModel.DataAnnotations;

namespace Application.Models.AppartmentModels.Response
{
    public class AppartmentResponse
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
        [Required]
        public float Rating { get; set; }
    }
}
