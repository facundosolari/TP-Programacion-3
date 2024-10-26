namespace Application.Models.BuildingModels.Response
{
    public class BuildingResponse
    {
        public string Ubication { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public bool Garage { get; set; }
        public bool BackYard { get; set; }
        public float Rating { get; set; }
    }
}
