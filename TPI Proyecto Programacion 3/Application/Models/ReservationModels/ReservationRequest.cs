namespace Application.Models.ReservationModels
{
    public class ReservationRequest
    {
        public int TenantID { get; set; }
        public DateOnly VisitDate { get; set; }
    }
}
