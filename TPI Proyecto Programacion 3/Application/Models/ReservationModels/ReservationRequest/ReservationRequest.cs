using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.ReservationModels.ReservationRequest
{
    public class ReservationRequest
    {
        public int TenantID { get; set; }
        public DateOnly VisitDate { get; set;}
    }
}
