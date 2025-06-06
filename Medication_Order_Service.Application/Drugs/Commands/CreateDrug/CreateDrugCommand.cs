using MediatR;
using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Domain.Drugs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Drugs.Commands.CreateDrug
{
    public class CreateDrugCommand : ICommand<Unit>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string SKU { get; set; } = null!;
        public Guid DrugCategoryId { get; set; } 
        public Guid DosageFormTypeId { get; set; }
    }
}
