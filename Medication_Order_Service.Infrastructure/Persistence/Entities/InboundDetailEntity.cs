using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Entities
{
    public class InboundDetailEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int InboundId { get; set; }
        public int Quantity { get; set; }
        public int DrugUnitId { get; set; }
        public int LotId { get; set; }

        public InboundEntity Inbound { get; set; } = null!;
        public DrugUnitEntity DrugUnit { get; set; } = null!;
        public LotEntity Lot { get; set; } = null!;
    }
}
