using Medication_Order_Service.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Abstractions
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken = default);
    }
}
