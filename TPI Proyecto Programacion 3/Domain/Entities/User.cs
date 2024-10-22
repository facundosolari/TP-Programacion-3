using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(40)")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(40)")]
        public string Lastname { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public virtual bool isAdmin { get; set; } = false;
    }
}
