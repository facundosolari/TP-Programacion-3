using System.ComponentModel.DataAnnotations;

namespace Application.Models.AppartmentModels.Request
{
    public class RatingRequest
    {
        [Required]
        public int TenantId { get; set; }
        [Required]
        public int Rating { get; set; }
    }
}
