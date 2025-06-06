using CSharpFunctionalExtensions;
using MediatR;
using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Application.Drugs.Commands.CreateDrugCategory;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Common.Errors;
using Medication_Order_Service.Domain.Drugs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Drugs.Commands.CreateDrugDosageForm
{
    public class CreateDrugDosageFormCommandHandler : ICommandHandler<CreateDrugDosageFormCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateDrugDosageFormCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<Result<Unit, IDomainError>> Handle(CreateDrugDosageFormCommand request, CancellationToken cancellationToken)
        {
            var existingDosage = await _unitOfWork.DrugDosageFormRepository.ExistsByNameAsync(request.Name, cancellationToken);

            if (existingDosage)
            {
                return Result.Failure<Unit, IDomainError>(DomainError.Conflict($"Drug dosage form with name '{request.Name}' already exists."));
            }
            var dosageForm = DosageForm.Create(request.Name, request.Description);

            await _unitOfWork.DrugDosageFormRepository.AddAsync(dosageForm, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success<Unit, IDomainError>(Unit.Value);
        }
    }
}
