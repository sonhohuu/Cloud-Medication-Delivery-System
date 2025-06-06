using MediatR;
using Medication_Order_Service.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Drugs.Commands.CreateDrugDosageForm
{
    public class CreateDrugDosageFormCommand : ICommand<Unit>
    {
        public string Name { get; init; } = null!;
        public string Description { get; init; } = null!;
    }
}
