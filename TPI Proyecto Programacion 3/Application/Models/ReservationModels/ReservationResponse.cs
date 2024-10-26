namespace Application.Models.ReservationModels
{
    public class ReservationResponse
    {
        public int ReservationID { get; set; }
        public int AppartmentID { get; set; }
        public int TenantID { get; set; }
        public DateOnly VisitDate { get; set; }
        public string Status { get; set; }
    }
}
