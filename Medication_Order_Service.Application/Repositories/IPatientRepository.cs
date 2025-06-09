using Medication_Order_Service.Application.Patients.Queries.FilterPatient;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Repositories
{
    public interface IPatientRepository : IReadRepository<Patient, Guid>,
        IUpdateRepository<Patient>,
        IAddRepository<Patient>
    {
        Task<PagedList<Patient>> FilterPatientAsync(FilterPatientQuery request);
    }
}
