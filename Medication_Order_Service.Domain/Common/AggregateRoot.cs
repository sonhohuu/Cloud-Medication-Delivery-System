using Medication_Order_Service.Domain.Common.Events;
using Medication_Order_Service.Domain.Common.Extensions;
using Medication_Order_Service.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.Common
{
    public abstract class AggregateRoot<TModel> : Entity<TModel>, IAggregateRoot
        where TModel : IAuditableEntity
    {
        private readonly IList<IDomainEvent> _domainEvents = [];

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        protected AggregateRoot(Id<TModel> id) : base(id) { }

        public IReadOnlyCollection<IDomainEvent> PopDomainEvents()
        {
            var events = _domainEvents.ToList();
            ClearEvents();
            return events;
        }
        public void ClearEvents()
        {
            _domainEvents.Clear();
        }

        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            domainEvent.EnsureNonNull();
            _domainEvents.Add(domainEvent);
        }
    }
}
