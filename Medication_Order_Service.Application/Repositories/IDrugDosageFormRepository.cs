using Medication_Order_Service.Domain.Drugs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Repositories
{
    public interface IDrugDosageFormRepository
        : IAddRepository<DosageForm>,
        IUpdateRepository<DosageForm>,
        IReadRepository<DosageForm, Guid>
    {
        Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
    }
}
