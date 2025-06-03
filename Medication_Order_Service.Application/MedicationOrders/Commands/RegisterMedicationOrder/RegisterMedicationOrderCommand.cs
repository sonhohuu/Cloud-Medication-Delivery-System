using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Application.MedicationOrders.Dtos;
using Medication_Order_Service.Common;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.MedicationOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.MedicationOrders.Commands.RegisterMedicationOrder
{
    public record class RegisterMedicationOrderCommand(
            PatientRequest patient,
            int waitingNumber,
            MedicationOrderRoom medicationRoom,
            MedicationOrderPriority priority,
            string? note = null) : ICommand<Id<MedicationOrder>>;

    public class PatientRequest
    {
        public string FullName { get; init; } = default!;
        public DateTime DateOfBirth { get; init; }
        public string Gender { get; init; } = default!;
        public string? Phone { get; init; }
        public string? Email { get; init; }
        public string? Address { get; init; }
        public string? Allergies { get; init; }
        public decimal Weight { get; init; }
    }
}
