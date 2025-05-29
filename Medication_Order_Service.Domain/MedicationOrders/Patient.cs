using Medication_Order_Service.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.MedicationOrders
{
    public class Patient : Entity<Patient>
    {
        public bool IsActive { get; }

        private Patient(bool isActive, Id<Patient>? id)
            : base(id ?? Id<Patient>.New())
        {
            IsActive = isActive;
        }

        public static Patient Create(bool isActive, Id<Patient>? id = null)
        {
            return new Patient(isActive, id);
        }
    }
}
