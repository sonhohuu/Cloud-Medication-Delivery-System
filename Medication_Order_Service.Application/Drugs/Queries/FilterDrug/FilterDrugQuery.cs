using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Drugs;
using Medication_Order_Service.Domain.Drugs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Drugs.Queries.FilterDrug
{
    public class FilterDrugQuery : IQuery<PagedList<Drug>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Name { get; set; }
        public bool? IsActive { get; private set; }
        public Guid? DrugCategoryId { get; private set; }
        public Guid? DosageFormTypeId { get; private set; }
    }
}
