namespace Contract.ReservationModels.Request
{
    public class ReservationRequest
    {
        public int AppartmentID { get; set; }
        public int TenantID { get; set; }
        public DateTime VisitDate { get; set; }
    }
}