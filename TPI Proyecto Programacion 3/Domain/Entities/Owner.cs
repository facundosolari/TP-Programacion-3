namespace Domain.Entities
{
    public class Owner : User
    {
        public List<Building>? Buildings { get; set; }
        public string? Photo { get; set; }
        public float? Rating { get; set; }

        public void UpdateAverageRating()
        {
            if (Buildings == null)
            {
                Rating = 0; 
                return;
            }

            Rating = Buildings.Sum(b => b.Rating) / Buildings.Count; // Calcular el promedio
        }
    }

}