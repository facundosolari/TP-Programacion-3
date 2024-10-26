using System.ComponentModel.DataAnnotations;

namespace Application.Models.AdminModels
{
    public class AdminResponse
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
