using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Entities
{
    public class MedicationOrderItemEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MedicationOrderId { get; set; }
        public int LotId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Dosage { get; set; } = null!;
        public string Frequency { get; set; } = null!;
        public string Duration { get; set; } = null!;

        public MedicationOrderEntity MedicationOrder { get; set; } = null!;
        public LotEntity Lot { get; set; } = null!;
    }
}
