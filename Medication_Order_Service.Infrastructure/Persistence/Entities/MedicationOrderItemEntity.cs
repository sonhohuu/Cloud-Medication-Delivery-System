﻿using System;
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
        public Guid Id { get; set; }
        public Guid MedicationOrderId { get; set; }
        public Guid DrugId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Dosage { get; set; } = null!;
        public string Frequency { get; set; } = null!;
        public string Duration { get; set; } = null!;
        public MedicationOrderEntity MedicationOrder { get; set; } = null!;
        public DrugEntity Drug { get; set; } = null!;
    }
}
