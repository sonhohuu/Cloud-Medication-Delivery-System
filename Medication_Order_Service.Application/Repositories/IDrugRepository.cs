using Medication_Order_Service.Application.Drugs.Queries.FilterDrug;
using Medication_Order_Service.Application.Patients.Queries.FilterPatient;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Drugs;
using Medication_Order_Service.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Repositories
{
    public interface IDrugRepository : IReadRepository<Drug, Guid>,
        IAddRepository<Drug>,
        IUpdateRepository<Drug>
    {
        Task<PagedList<Drug>> FilterDrugAsync(FilterDrugQuery request);
    }
}
