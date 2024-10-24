using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Models.BuildingModels.Request
{
    public class BuildingRequest
    {
        public int BuildingId { get; set; }
        public string Ubication { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public bool Garage { get; set; }
        public bool BackYard { get; set; }
        public int? Rating { get; set; }
        public List<Appartment> Appartments { get; set; } = new List<Appartment>();
    }
}
