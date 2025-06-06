using Medication_Order_Service.Domain.Drugs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Repositories
{
    public interface IDrugCategoryRepository 
        : IAddRepository<DrugCategory>,
        IUpdateRepository<DrugCategory>,
        IReadRepository<DrugCategory, Guid>
    {
        Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
    }
}
