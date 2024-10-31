using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models.AppartmentModels.Request
{
    public class RatingRequest
    {
        [Required]
        public int Value { get; set; }
        [Required]
        public int AppartmentId { get; set; }
        [Required]
        public int TenantId { get; set; }
    }
}
