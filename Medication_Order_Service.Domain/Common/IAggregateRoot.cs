using Medication_Order_Service.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.Common
{
    public interface IAggregateRoot
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
        IReadOnlyCollection<IDomainEvent> PopDomainEvents();
        void ClearEvents();
    }
}
