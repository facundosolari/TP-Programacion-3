﻿using Domain.Entities;

namespace Contract.AppartmentModels.Request
{
    public class AppartmentRequest
    {
        public int AppartmentID { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public int Bathrooms { get; set; }
        public int Rooms { get; set; }
        public List<string> Pictures { get; set; } = new List<string>();
        public string Description { get; set; } = string.Empty;
        public float Price { get; set; }
        public Tenant? Tenant { get; set; }
    }
}
