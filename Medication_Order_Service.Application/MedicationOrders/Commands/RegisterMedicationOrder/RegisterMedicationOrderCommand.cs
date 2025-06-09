using MediatR;
using Medication_Order_Service.Application.Abstractions;
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
            Guid patientId,
            int waitingNumber,
            MedicationOrderRoom medicationRoom,
            MedicationOrderPriority priority,
            string? note = null) : ICommand<Unit>;
}
