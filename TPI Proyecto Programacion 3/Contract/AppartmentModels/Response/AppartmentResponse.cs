using Domain.Entities;

namespace Contract.AppartmentModels.Response
{
    public class AppartmentResponse
    {
        public int Floor { get; set; }
        public int Number { get; set; }
        public int Bathrooms { get; set; }
        public int Rooms { get; set; }
        public string? Description { get; set; }
        public int? Rating { get; set; }

        public int Id { get; set; }

        public int BuildingId { get; set; }

        public Tenant? Tenant { get; set; }
        public float Price { get; set; }
        public bool IsAvailable { get; set; }
        public List<string>? Pictures { get; set; }
    }
}
