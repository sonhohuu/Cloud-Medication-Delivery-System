using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Common
{
    public enum MedicationOrderStatus
    {
        Pending,
        Verified,
        Dispensed,
        Paid,
        Cancelled
    }

    public enum InboundStatus
    {
        Pending,
        Received,
        Cancelled
    }

    public enum MedicationOrderPriority
    {
        Routine,
        Urgent,
        Stat
    }

    public enum MedicationOrderRoom
    {
        Room101,
        Room102,
        Room103,
        Room104,    
        Room105
    }
}
