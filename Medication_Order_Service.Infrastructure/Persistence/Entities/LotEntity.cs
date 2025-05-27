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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DrugId { get; set; }
        public int StorageLocationId { get; set; }
        public string BatchNumber { get; set; } = null!;
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Note { get; set; } = null!;
        public int Quantity { get; set; }

        public DrugEntity Drug { get; set; } = null!;
        public StorageLocationEntity StorageLocation { get; set; } = null!;
        public ICollection<MedicationOrderItemEntity> MedicationOrderItems { get; set; } = new List<MedicationOrderItemEntity>();
        public virtual ICollection<LotTransferEntity> LotTransfers { get; set; } = new List<LotTransferEntity>();
    }
}
