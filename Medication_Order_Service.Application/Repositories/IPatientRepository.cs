using Medication_Order_Service.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Repositories
{
    public interface IPatientRepository : IUpdateRepository<Patient>, 
        IReadRepository<Patient, Guid>, 
        IDeleteRepository<Guid>,
        IAddRepository<Patient>
    {

    }
}
