namespace Domain.Entities
{
    public class Tenant : User
    {
        public string? Photo { get; set; }
        public int? AppartmentId { get; set; } // foreign key
        public Appartment? Appartment { get; set; }
    }
}
