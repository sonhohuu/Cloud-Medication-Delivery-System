using Medication_Order_Service.Domain.MedicationOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Repositories
{
    public interface IReadRepository<TDomain, T>
    {
        Task<TDomain?> GetByIdAsync(T id);
        Task<bool> IsExistsAsync(T id);
        Task<int> CountAsync();
    }
}
