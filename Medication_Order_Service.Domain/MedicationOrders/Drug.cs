using Medication_Order_Service.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.MedicationOrders
{
    public sealed class Drug : Entity<Drug>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public string DosageForm { get; set; } = null!;
        public decimal Price { get; set; }
        public Drug() : base() { }
        public Drug(Id<Drug> id) : base(id) { }
    }
}
