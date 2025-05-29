using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.MedicationOrders
{
    public sealed class MedicationOrderItem : Entity<MedicationOrderItem>
    {
        public const int MinItemCount = 1;
        public Drug Drug { get; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public string Dosage { get; private set; }
        public string Frequency { get; private set; }
        public string Duration { get; private set; }

        private MedicationOrderItem(
            Id<MedicationOrderItem>? id,
            Drug drug,
            int quantity,
            decimal unitPrice,
            string dosage,
            string frequency,
            string duration) : base(id ?? Id<MedicationOrderItem>.New())
        {
            Drug.EnsureNonNull(nameof(drug));
            Quantity.EnsureGreaterThan(MinItemCount, nameof(quantity));
            UnitPrice.EnsureNonNegative(nameof(unitPrice));
            Dosage.EnsureNonNull(nameof(dosage));
            Frequency.EnsureNonNull(nameof(frequency));
            Duration.EnsureNonNull(nameof(duration));
        }

        public static MedicationOrderItem Create(Id<MedicationOrderItem>? id, Drug drug, int quantity, decimal unitPrice, string dosage, string frequency, string duration)
        {
            return new MedicationOrderItem(id, drug, quantity, unitPrice, dosage, frequency, duration);
        }

    }
}
