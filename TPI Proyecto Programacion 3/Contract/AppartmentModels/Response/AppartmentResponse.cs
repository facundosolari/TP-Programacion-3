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

        public int? TenantId { get; set; }
    }
}
