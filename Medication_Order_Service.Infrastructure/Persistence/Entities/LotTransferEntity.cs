﻿using System;
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
        public Guid Id { get; set; }
        public Guid LotId { get; set; }
        public Guid From { get; set; }
        public Guid To { get; set; }
        public string Note { get; set; } = null!;
        public int Quantity { get; set; }

        public LotEntity Lot { get; set; } = null!;
        public virtual StorageLocationEntity FromLocation { get; set; } = null!;
        public virtual StorageLocationEntity ToLocation { get; set; } = null!;
    }
}
