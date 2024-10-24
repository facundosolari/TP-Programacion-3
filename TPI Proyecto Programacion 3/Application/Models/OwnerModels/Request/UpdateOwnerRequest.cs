using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.OwnerModels.Request
{
    public class UpdateOwnerRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Building> Property { get; set; } = new List<Building>();
        public string? Photo { get; set; }
        public int? Rating { get; set; }
    }
}
