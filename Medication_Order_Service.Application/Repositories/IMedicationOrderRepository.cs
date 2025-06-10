using Medication_Order_Service.Application.Drugs.Queries.FilterDrug;
using Medication_Order_Service.Application.MedicationOrders.Queries.FilterMedicationOrder;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Drugs;
using Medication_Order_Service.Domain.MedicationOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Repositories
{
    public interface IMedicationOrderRepository : IAddRepository<MedicationOrder>, 
        IUpdateRepository<MedicationOrder>, 
        IReadRepository<MedicationOrder, Guid>
    {
        Task<PagedList<MedicationOrder>> FilterMedicationOrderAsync(FilterMedicationOrderQuery request);
    }
}
