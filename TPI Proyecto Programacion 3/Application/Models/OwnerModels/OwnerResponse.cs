using System.ComponentModel.DataAnnotations;

namespace Application.Models.OwnerModels
{
    public class OwnerResponse
    {
        public int userId { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required] 
        public string lastName { get; set; }
        public string? photo { get; set; }
        public string role { get; set; } = "Tenant";
    }
}
