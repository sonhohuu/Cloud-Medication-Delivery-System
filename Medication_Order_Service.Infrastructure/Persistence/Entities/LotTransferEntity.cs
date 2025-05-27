using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Entities
{
    public class LotTransferEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int LotId { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string Note { get; set; } = null!;
        public int Quantity { get; set; }

        public LotEntity Lot { get; set; } = null!;
        public virtual StorageLocationEntity FromLocation { get; set; } = null!;
        public virtual StorageLocationEntity ToLocation { get; set; } = null!;
    }
}
