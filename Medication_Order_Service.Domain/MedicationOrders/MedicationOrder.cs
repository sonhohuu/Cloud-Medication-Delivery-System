using Medication_Order_Service.Common;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Exceptions;
using Medication_Order_Service.Domain.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.MedicationOrders
{
    public class MedicationOrder : AggregateRoot<MedicationOrder>
    {
        // Private fields for encapsulation
        private readonly List<MedicationOrderItem> _items = new();
        private MedicationOrderStatus _status;
        private string? _notes;

        // Properties
        public int PatientId { get; private set; }
        public Guid DoctorId { get; private set; }
        public MedicationOrderStatus Status => _status;
        public Guid CreatedByAccountId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? Notes => _notes;
        public int WaitingNumber { get; private set; }
        public MedicationOrderRoom MedicationRoom { get; private set; }
        public MedicationOrderPriority Priority { get; private set; }

        // Navigation properties (readonly collections)
        public IReadOnlyCollection<MedicationOrderItem> Items => _items.AsReadOnly();
        private MedicationOrder() { }

        public static MedicationOrder Create(
            int patientId,
            Guid createdByAccountId,
            int waitingNumber,
            MedicationOrderRoom medicationRoom,
            MedicationOrderPriority priority,
            string? notes = null)
        {
            // Domain validation
            patientId.EnsureNonZero(nameof(patientId));
            createdByAccountId.EnsureNonNull(nameof(createdByAccountId));
            

            var order = new MedicationOrder
            {
                PatientId = patientId,
                _status = MedicationOrderStatus.Pending,
                CreatedByAccountId = createdByAccountId,
                CreatedAt = DateTime.UtcNow,
                _notes = notes,
                WaitingNumber = waitingNumber,
                MedicationRoom = medicationRoom,
                Priority = priority
            };

            // Raise domain event
            //order.AddDomainEvent(new MedicationOrderCreatedEvent(order.Id, order.PatientId, order.WaitingNumber));

            return order;
        }

        public void AddMedicationItem(
            Guid drugId,
            int quantityOrdered,
            string dosage,
            string route,
            string frequency,
            string duration,
            decimal unitPrice,
            string? instructions = null)
        {
            _status.EnsureEnumValueDefined(MedicationOrderStatus.Pending.ToString());

            var item = MedicationOrderItem.Create(
                drugId, quantityOrdered, dosage, route, frequency, duration, unitPrice, instructions);

            _items.Add(item);
        }

        public void VerifyByDoctor(Guid doctorId)
        {
            if (Status != MedicationOrderStatus.Pending)
                throw new ValidationException("Only pending orders can be verified.");

            VerifiedByDoctorId = doctorId;
            Status = MedicationOrderStatus.Verified;
        }

        public void MarkAsDispensed(Guid receptionistId)
        {
            if (Status != MedicationOrderStatus.Verified)
                throw new DomainException("Only verified orders can be dispensed.");

            DispensedByReceptionistId = receptionistId;
            Status = MedicationOrderStatus.Dispensed;
        }

        public void MarkAsPaid(Guid patientId)
        {
            if (Status != MedicationOrderStatus.Dispensed)
                throw new DomainException("Only dispensed orders can be paid.");

            PaidByPatientId = patientId;
            Status = MedicationOrderStatus.Paid;
        }

        public void Cancel(Guid userId, string role)
        {
            if (Status == MedicationOrderStatus.Dispensed || Status == MedicationOrderStatus.Paid)
                throw new DomainException("Cannot cancel dispensed or paid orders.");

            Status = MedicationOrderStatus.Cancelled;
        }
    }

}
