using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Models.BuildingModels.Response
{
    public class BuildingResponse
    {
        public string Ubication { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public bool Garage { get; set; }
        public bool BackYard { get; set; }
        public int? Rating { get; set; }
    }
}
