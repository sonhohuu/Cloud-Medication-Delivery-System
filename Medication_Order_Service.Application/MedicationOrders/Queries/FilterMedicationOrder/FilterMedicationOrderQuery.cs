using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.MedicationOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.MedicationOrders.Queries.FilterMedicationOrder
{
    public class FilterMedicationOrderQuery : IQuery<PagedList<MedicationOrder>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public Guid? PatientId { get; set; }
    }
}
