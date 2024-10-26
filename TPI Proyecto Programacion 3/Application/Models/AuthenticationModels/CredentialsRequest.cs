using System.ComponentModel.DataAnnotations;

namespace Application.Models.AuthenticationModels
{
    public class CredentialsRequest
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
