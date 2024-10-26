namespace Application.Models.BuildingModels.Request
{
    public class BuildingRequest
    {
        public string Ubication { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public bool Garage { get; set; }
        public bool BackYard { get; set; }
        public int OwnerId { get; set; }
    }
}
