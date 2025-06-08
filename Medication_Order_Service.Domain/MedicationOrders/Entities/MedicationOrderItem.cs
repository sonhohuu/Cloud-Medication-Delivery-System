using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.MedicationOrders.Entities
{
    public class MedicationOrderItem : Entity<MedicationOrderItem>
    {
        public const int MinItemCount = 1;
        public Guid DrugId { get; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public string Dosage { get; private set; }
        public string Frequency { get; private set; }
        public string Duration { get; private set; }
        private MedicationOrderItem(Id<MedicationOrderItem> id) : base(id) { }

        public static MedicationOrderItem Create(Guid drug, int quantity, decimal unitPrice, string dosage, string frequency, string duration)
        {
            quantity.EnsureGreaterThan(MinItemCount, nameof(quantity));
            unitPrice.EnsureNonNegative(nameof(unitPrice));
            dosage.EnsureNonNull(nameof(dosage));
            frequency.EnsureNonNull(nameof(frequency));
            duration.EnsureNonNull(nameof(duration));
            return new MedicationOrderItem(Id<MedicationOrderItem>.New())
            {
                Quantity = quantity,
                UnitPrice = unitPrice,
                Dosage = dosage,
                Frequency = frequency,
                Duration = duration
            };
        }

    }
}
