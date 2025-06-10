using Medication_Order_Service.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.MedicationOrders.Entities
{
    public class Bill : Entity<Bill>
    {
        public decimal TotalAmount { get; private set; }
        public DateTime IssuedAt { get; private set; }
        private Bill(Id<Bill> id) : base(id)
        {
        }
        public static Bill Create(decimal totalAmount)
        {
            return new Bill(Id<Bill>.New())
            {
                TotalAmount = totalAmount,
                IssuedAt = DateTime.UtcNow
            };
        }
    }
}
