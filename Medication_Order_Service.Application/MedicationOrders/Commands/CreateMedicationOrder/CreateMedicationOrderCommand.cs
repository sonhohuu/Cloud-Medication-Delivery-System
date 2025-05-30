using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Application.MedicationOrders.Dtos;
using Medication_Order_Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.MedicationOrders.Commands.CreateMedicationOrder
{
    public record class CreateMedicationOrderCommand(
            PatientRequest patient,
            Guid createdByAccountId,
            int waitingNumber,
            MedicationOrderRoom medicationRoom,
            MedicationOrderPriority priority,
            string? note = null) : ICommand<int>;

    public class PatientRequest
    {
        public string FullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Allergies { get; set; }
        public decimal Weight { get; set; }
    }
}
