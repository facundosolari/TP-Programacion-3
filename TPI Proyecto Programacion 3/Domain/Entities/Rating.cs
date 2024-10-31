using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Value { get; set; }

        [ForeignKey("AppartmentId")]
        public int AppartmentId { get; set; }
        public Appartment Appartment { get; set; }

        [ForeignKey("TenantId")]
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
