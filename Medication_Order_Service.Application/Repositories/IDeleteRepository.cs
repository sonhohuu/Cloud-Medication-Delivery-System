using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Repositories
{
    public interface IDeleteRepository<T>
    {
        Task DeleteAsync(T id, CancellationToken cancellationToken);
    }
}
