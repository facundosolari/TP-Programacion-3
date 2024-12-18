﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationID { get; set; }

        [ForeignKey("AppartmentID")]
        public int AppartmentID { get; set; }
        public Appartment Appartment { get; set; }

        [ForeignKey("TenantID")]
        public int TenantID { get; set; }
        public Tenant Tenant { get; set; }
        [Required]
        public DateOnly VisitDate { get; set; }
    }
}
