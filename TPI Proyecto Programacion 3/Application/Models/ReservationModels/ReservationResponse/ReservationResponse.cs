namespace Contract.ReservationModels.Response
{
    public class ReservationResponse
    {
        public int ReservationID { get; set; }
        public int AppartmentID { get; set; }
        public string AppartmentDescription { get; set; }
        public int TenantID { get; set; }
        public string TenantName { get; set; }
        public DateTime VisitDate { get; set; }
        public string Status { get; set; }
    }
}
