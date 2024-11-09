using System.ComponentModel.DataAnnotations;

namespace Application.Models.AdminModels
{
    public class AdminResponse
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
        public string photo { get; set; } = "https://w7.pngwing.com/pngs/867/694/png-transparent-user-profile-default-computer-icons-network-video-recorder-avatar-cartoon-maker-blue-text-logo.png";
        public string role { get; set; } = "Admin";
    }
}
