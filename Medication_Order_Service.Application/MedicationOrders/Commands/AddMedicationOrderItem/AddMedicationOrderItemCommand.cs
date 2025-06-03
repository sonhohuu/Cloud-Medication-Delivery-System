using MediatR;
using Medication_Order_Service.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.MedicationOrders.Commands.AddMedicationOrderItem
{
    public record class AddMedicationOrderItemCommand : ICommand<Unit>
    {
        public int MedicationOrderId { get; init; }

        public List<MedicationOrderItemRequest> Items { get; init; } = new();
        public string? Note { get; init; }
    }

    public record class MedicationOrderItemRequest
    {
        public int DrugId { get; init; }
        public int Quantity { get; init; }
        public string Dosage { get; init; } = default!;
        public decimal UnitPrice { get; init; }
        public string Duration { get; init; } = default!;
        public string Frequency { get; init; } = default!;
    }
}
