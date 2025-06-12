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
        public Guid Id { get; set; }
        public Guid InboundId { get; set; }
        public int ExpectedQuantity { get; set; }
        public int ActualQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid DrugUnitId { get; set; }
        public Guid? LotId { get; set; }

        public InboundEntity Inbound { get; set; } = null!;
        public DrugUnitEntity DrugUnit { get; set; } = null!;
        public LotEntity? Lot { get; set; }
    }
}
