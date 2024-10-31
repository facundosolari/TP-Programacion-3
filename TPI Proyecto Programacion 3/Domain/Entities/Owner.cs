namespace Domain.Entities
{
    public class Owner : User
    {
        public List<Building> Buildings { get; set; } = new List<Building>();
        public string? Photo { get; set; }
    }

}