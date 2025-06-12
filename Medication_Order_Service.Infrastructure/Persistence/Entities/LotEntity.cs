using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Entities
{
    public class LotEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid DrugId { get; set; }
        public Guid? StorageLocationId { get; set; }
        public string? BatchNumber { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? Note { get; set; } = null!;
        public int Quantity { get; set; }

        public DrugEntity Drug { get; set; } = null!;
        public StorageLocationEntity StorageLocation { get; set; } = null!;
        public ICollection<LotTransferEntity> LotTransfers { get; set; } = new List<LotTransferEntity>();
        public ICollection<InboundDetailEntity> InboundDetailEntities { get; set; } = new List<InboundDetailEntity>();
    }
}
