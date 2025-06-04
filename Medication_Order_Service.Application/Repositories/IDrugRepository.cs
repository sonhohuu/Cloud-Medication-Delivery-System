using Medication_Order_Service.Domain.Drugs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Repositories
{
    public interface IDrugRepository : IReadRepository<Drug, Guid>,
        IAddRepository<Drug>,
        IUpdateRepository<Drug>,
        IDeleteRepository<Guid>
    {
    }
}
