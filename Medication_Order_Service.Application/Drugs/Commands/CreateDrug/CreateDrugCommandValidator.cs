using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Drugs.Commands.CreateDrug
{
    public class CreateDrugCommandValidator : AbstractValidator<CreateDrugCommand>
    {
        public CreateDrugCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Drug name is required.")
                .MaximumLength(100).WithMessage("Drug name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(x => x.SKU)
                .NotEmpty().WithMessage("SKU is required.")
                .MaximumLength(50).WithMessage("SKU must not exceed 50 characters.");

            RuleFor(x => x.DrugCategoryId)
                .NotEmpty().WithMessage("Drug category ID is required.");

            RuleFor(x => x.DosageFormTypeId)
                .NotEmpty().WithMessage("Dosage form type ID is required.");
        }
    }
}
