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
        // Properties
        public int PatientId { get; private set; }
        public Patient Patient { get; private set; }
        public Guid DoctorId { get; private set; }
        public MedicationOrderStatus Status { get; private set; }
        public Guid CreatedByAccountId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? Notes { get; private set; }
        public int WaitingNumber { get; private set; }
        public MedicationOrderRoom MedicationRoom { get; private set; }
        public MedicationOrderPriority Priority { get; private set; }

        // Navigation properties (readonly collections)
        private readonly List<MedicationOrderItem> _items = new();
        public IReadOnlyCollection<MedicationOrderItem> Items => _items.AsReadOnly();

        public static MedicationOrder Create(
            Patient patient,
            Guid createdByAccountId,
            int waitingNumber,
            MedicationOrderRoom medicationRoom,
            MedicationOrderPriority priority,
            string? notes = null)
        {
            // Domain validation
            createdByAccountId.EnsureNonNull(nameof(createdByAccountId));
            if (patient.IsTreating)
                throw new ValidationException("Patient is being treating.");

            var order = new MedicationOrder
            {
                Patient = patient,
                Status = MedicationOrderStatus.Pending,
                CreatedByAccountId = createdByAccountId,
                CreatedAt = DateTime.UtcNow,
                Notes = notes,
                WaitingNumber = waitingNumber,
                MedicationRoom = medicationRoom,
                Priority = priority
            };

            // Raise domain event
            //order.AddDomainEvent(new MedicationOrderCreatedEvent(order.Id, order.PatientId, order.WaitingNumber));

            return order;
        }

        public static MedicationOrder Create(
            int patientId,
            Guid createdByAccountId,
            int waitingNumber,
            MedicationOrderRoom medicationRoom,
            MedicationOrderPriority priority,
            string? notes = null)
        {
            // Domain validation
            createdByAccountId.EnsureNonNull(nameof(createdByAccountId));

            var order = new MedicationOrder
            {
                PatientId = patientId,
                Status = MedicationOrderStatus.Pending,
                CreatedByAccountId = createdByAccountId,
                CreatedAt = DateTime.UtcNow,
                Notes = notes,
                WaitingNumber = waitingNumber,
                MedicationRoom = medicationRoom,
                Priority = priority
            };

            // Raise domain event
            //order.AddDomainEvent(new MedicationOrderCreatedEvent(order.Id, order.PatientId, order.WaitingNumber));

            return order;
        }

        public void AddMedicationItem(MedicationOrderItem medicationOrderItem)
        {
            if (Status != MedicationOrderStatus.Pending)
                throw new ValidationException("Only pending Medication Order can have items added.");

            var item = MedicationOrderItem.Create(medicationOrderItem.Drug, medicationOrderItem.Quantity, medicationOrderItem.UnitPrice, medicationOrderItem.Duration, medicationOrderItem.Frequency, medicationOrderItem.Duration);

            _items.Add(item);
        }

        public void VerifyByDoctor(Guid doctorId, string? note)
        {
            if (Status != MedicationOrderStatus.Pending)
                throw new ValidationException("Only pending orders can be verified.");

            DoctorId = doctorId;
            Status = MedicationOrderStatus.Verified;
        }

        public void MarkAsDispensed(Guid receptionistId)
        {
            if (Status != MedicationOrderStatus.Verified)
                throw new ValidationException("Only verified orders can be dispensed.");

            Status = MedicationOrderStatus.Dispensed;
        }

        public void MarkAsPaid(Guid patientId)
        {
            if (Status != MedicationOrderStatus.Dispensed)
                throw new ValidationException("Only dispensed orders can be paid.");

            Status = MedicationOrderStatus.Paid;
        }

        public void Cancel(Guid userId, string role)
        {
            if (Status == MedicationOrderStatus.Dispensed || Status == MedicationOrderStatus.Paid)
                throw new ValidationException("Cannot cancel dispensed or paid orders.");

            Status = MedicationOrderStatus.Cancelled;
        }
    }

}
