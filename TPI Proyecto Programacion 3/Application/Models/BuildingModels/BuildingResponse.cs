using System.ComponentModel.DataAnnotations;

namespace Application.Models.BuildingModels.Response
{
    public class BuildingResponse
    {
        [Required]
        public string Ubication { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public bool Garage { get; set; }
        [Required]
        public bool BackYard { get; set; }
        [Required]
        public float Rating { get; set; }
    }
}
