using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Enums
{
    public enum MedicationOrderStatus
    {
        Pending,
        Verified,
        Dispensed,
        Paid,
        Cancelled
    }
}
