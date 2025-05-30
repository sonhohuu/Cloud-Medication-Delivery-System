using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.MedicationOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Repositories
{
    public class MedicationOrderRepository : GenericRepository<MedicationOrder>, IMedicationOrderRepository
    {
        public MedicationOrderRepository(MedicationOrderServiceDbContext context) : base(context)
        {
        }
    }
}
