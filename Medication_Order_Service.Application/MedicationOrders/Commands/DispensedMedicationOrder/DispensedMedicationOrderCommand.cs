using MediatR;
using Medication_Order_Service.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Medication_Order_Service.Application.MedicationOrders.Commands.VerifiedMedicationOrder
{
    public record class DispensedMedicationOrderCommand : ICommand<Unit>
    {
        public string? note { get; init; }
    }
}
