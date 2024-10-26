using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.ReservationModels.ReservationResponse
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
