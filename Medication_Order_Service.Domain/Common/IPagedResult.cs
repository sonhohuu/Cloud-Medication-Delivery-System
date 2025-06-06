using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.Common
{
    public interface IPagedResult<out T> : IEnumerable<T>
    {
        int TotalCount { get; }
        int PageCount { get; }
        int PageNo { get; }
        int PageSize { get; }
    }
}
