using MediatR;
using Medication_Order_Service.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.MedicationOrders.Commands.AddMedicationOrderItem
{
    public class AddMedicationOrderItemCommand : ICommand<Unit>
    {
        public Guid MedicationOrderId { get; set; }
        public List<MedicationOrderItemRequest> Items { get; set; } = new();
        public string? Note { get; set; }
    }

    public class MedicationOrderItemRequest
    {
        public Guid DrugId { get; set; }
        public int Quantity { get; set; }
        public string Dosage { get; set; } = default!;
        public decimal UnitPrice { get; set; }
        public string Duration { get; set; } = default!;
        public string Frequency { get; set; } = default!;
    }
}