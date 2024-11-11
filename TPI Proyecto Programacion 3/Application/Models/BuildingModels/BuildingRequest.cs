using System.ComponentModel.DataAnnotations;

namespace Application.Models.BuildingModels.Request
{
    public class BuildingRequest
    {
        [Required]
        public string Ubication { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public bool Garage { get; set; }
        [Required]
        public bool BackYard { get; set; }
        public int OwnerId { get; set; }
    }
}
