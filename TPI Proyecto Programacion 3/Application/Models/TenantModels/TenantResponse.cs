using System.ComponentModel.DataAnnotations;

namespace Application.Models.TenantModels
{
    public class TenantResponse
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        public string Photo { get; set; }
    }
}
