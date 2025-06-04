using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Entities
{
    public class InventoryTransactionEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string ChangeType { get; set; } = null!;
        public int Quantity { get; set; }
        public Guid RelatedLotId { get; set; }
        public DateTime Timestamp { get; set; }

        public LotEntity RelatedLot { get; set; } = null!;
    }
}
