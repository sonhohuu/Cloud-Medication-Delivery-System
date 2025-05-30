using Medication_Order_Service.Domain.MedicationOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Repositories
{
    public interface IMedicationOrderRepository : IGenericRepository<MedicationOrder>
    {
        
    }
}
