using Medication_Order_Service.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.MedicationOrders
{
    public sealed class MedicationOrderItem : Entity<MedicationOrderItem>
    {
        public Drug Drug { get; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public string Dosage { get; private set; }
        public string Frequency { get; private set; }
        public string Duration { get; private set; }


    }
}
