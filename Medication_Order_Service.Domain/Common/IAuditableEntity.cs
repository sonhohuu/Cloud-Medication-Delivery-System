using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.Common
{
    public interface IAuditableEntity
    {
        public DateTimeOffset CreatedAtUtc { get; }
        public DateTimeOffset LastModifiedAtUtc { get; }
    }
}
