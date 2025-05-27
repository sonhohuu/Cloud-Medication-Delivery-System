using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Entities
{
    public class BillEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int MedicationOrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime IssuedAt { get; set; }
        public MedicationOrderEntity MedicationOrder { get; set; } = null!;
    }
}
