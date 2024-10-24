using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enum;

namespace Application.Models.BuildingModels.Response
{
    public class BuildingResponse
    {
        public string? Ubication { get; set; }
        public BuildingType Type { get; set; }
        public int Id { get; set; }
        public string? Adress { get; set; }
        public int Bathrooms { get; set; }
        public int Rooms { get; set; }
        public bool Garage { get; set; }
        public bool BackYard { get; set; }
        public List<string>? Pictures { get; set; } = new List<string>();
        public string? Description { get; set; }
        public int? Rating { get; set; }
    }
}
