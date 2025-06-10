using Medication_Order_Service.Common;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Exceptions;
using Medication_Order_Service.Domain.Common.Extensions;
using Medication_Order_Service.Domain.MedicationOrders.Entities;
using Medication_Order_Service.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.MedicationOrders
{
    public class MedicationOrder : AggregateRoot<MedicationOrder>
    {
        // Properties
        public Id<Patient>? PatientId { get; private set; }
        public Guid DoctorId { get; private set; }
        public MedicationOrderStatus Status { get; private set; }
        public Guid CreatedByAccountId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? Notes { get; private set; }
        public int WaitingNumber { get; private set; }
        public MedicationOrderRoom MedicationRoom { get; private set; }
        public MedicationOrderPriority Priority { get; private set; }
        public string? ReasonCancelled { get; set; }
        public Bill? Bill { get; private set; }
        public IReadOnlyCollection<MedicationOrderItem> Items => _items.AsReadOnly();

        // Navigation properties (readonly collections)
        private readonly List<MedicationOrderItem> _items = new();

        private MedicationOrder(Id<MedicationOrder> id) : base(id)
        {
        }

        public static MedicationOrder Create(
            Id<Patient> patientId,
            Guid createdByAccountId,
            int waitingNumber,
            MedicationOrderRoom medicationRoom,
            MedicationOrderPriority priority,
            string? notes = null)
        {
            // Domain validation
            createdByAccountId.EnsureNonNull(nameof(createdByAccountId));
            waitingNumber.EnsureGreaterThan(0, nameof(waitingNumber));

            var order = new MedicationOrder(Id<MedicationOrder>.New())
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

        public void Update(
            Id<Patient>? patientId,
            int? waitingNumber,
            MedicationOrderRoom? medicationRoom,
            MedicationOrderPriority? priority,
            string? notes = null)
        {
            if (patientId != null)
            {
                PatientId = patientId;
            }

            if (waitingNumber.HasValue)
            {
                waitingNumber.Value.EnsureGreaterThan(0, nameof(waitingNumber));
                WaitingNumber = waitingNumber.Value;
            }

            if (medicationRoom.HasValue)
            {
                MedicationRoom = medicationRoom.Value;
            }

            if (priority.HasValue)
            {
                Priority = priority.Value;
            }

            // Nullable: có thể ghi đè nếu muốn ghi nhận null (nếu muốn bỏ qua null thì thêm điều kiện)
            Notes = notes;
        }

        public void AddMedicationItem(MedicationOrderItem medicationOrderItem)
        {
            if (Status != MedicationOrderStatus.Pending)
                throw new ValidationException("Only pending Medication Order can have items added.");

            var item = MedicationOrderItem.Create(this.Id.Value, medicationOrderItem.DrugId, medicationOrderItem.Quantity, medicationOrderItem.UnitPrice, medicationOrderItem.Duration, medicationOrderItem.Frequency, medicationOrderItem.Duration);

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

        public void MarkAsPaid(Bill bill)
        {
            if (Status != MedicationOrderStatus.Dispensed)
                throw new ValidationException("Only dispensed orders can be paid.");

            Bill = bill;
            Status = MedicationOrderStatus.Paid;
        }

        public void Cancel(string reasonCancelled)
        {
            if (Status == MedicationOrderStatus.Dispensed || Status == MedicationOrderStatus.Paid)
                throw new ValidationException("Cannot cancel dispensed or paid orders.");

            ReasonCancelled = reasonCancelled;
            Status = MedicationOrderStatus.Cancelled;
        }
    }

}
