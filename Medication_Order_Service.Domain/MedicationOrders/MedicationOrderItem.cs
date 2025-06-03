using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.MedicationOrders
{
    public sealed class MedicationOrderItem
    {
        public const int MinItemCount = 1;
        public int DrugId { get; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public string Dosage { get; private set; }
        public string Frequency { get; private set; }
        public string Duration { get; private set; }

        private MedicationOrderItem(
            int drugId,
            int quantity,
            decimal unitPrice,
            string dosage,
            string frequency,
            string duration)
        {
            Quantity.EnsureGreaterThan(MinItemCount, nameof(quantity));
            UnitPrice.EnsureNonNegative(nameof(unitPrice));
            Dosage.EnsureNonNull(nameof(dosage));
            Frequency.EnsureNonNull(nameof(frequency));
            Duration.EnsureNonNull(nameof(duration));

            DrugId = drugId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Dosage = dosage;
            Frequency = frequency;
            Duration = duration;
        }

        public static MedicationOrderItem Create(int drug, int quantity, decimal unitPrice, string dosage, string frequency, string duration)
        {
            return new MedicationOrderItem(drug, quantity, unitPrice, dosage, frequency, duration);
        }

    }
}
