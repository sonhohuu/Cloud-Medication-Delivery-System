using CSharpFunctionalExtensions;
using MediatR;
using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Application.Drugs.Commands.CreateDrug;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Errors;
using Medication_Order_Service.Domain.Drugs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Drugs.Commands.UpdateDrug
{
    public class UpdateDrugCommandHandler : CommandHandlerBase<UpdateDrugCommand, Unit>
    {
        public UpdateDrugCommandHandler(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
        protected override async Task<Result<Unit, IDomainError>> ExecuteAsync(
            UpdateDrugCommand request, CancellationToken cancellationToken)
        {
            if (request.DrugCategoryId.HasValue)
            {
                var drugCategoryExist = await _unitOfWork.DrugCategoryRepository.GetByIdAsync(request.DrugCategoryId.Value, cancellationToken);
                if (drugCategoryExist is null)
                {
                    return Result.Failure<Unit, IDomainError>(DomainError.NotFound($"Drug category with id {request.DrugCategoryId} not found."));
                }
            }
            
            if (request.DosageFormTypeId.HasValue)
            {
                var dosageFormExist = await _unitOfWork.DrugDosageFormRepository.GetByIdAsync(request.DosageFormTypeId.Value, cancellationToken);
                if (dosageFormExist is null)
                {
                    return Result.Failure<Unit, IDomainError>(DomainError.NotFound($"Dosage form with id {request.DosageFormTypeId} not found."));
                }
            }
            
            var drug = await _unitOfWork.DrugRepository.GetByIdAsync(request.Id, cancellationToken);
            if (drug == null)
            {
                return Result.Failure<Unit, IDomainError>(DomainError.NotFound($"Drug with id {request.Id} not found."));
            }
            
            drug.Update(
                request.Name,
                request.Description,
                request.Price,
                request.SKU,
                request.DrugCategoryId.HasValue ? await _unitOfWork.DrugCategoryRepository.GetByIdAsync(request.DrugCategoryId.Value, cancellationToken) : drug.DrugCategory,
                request.DosageFormTypeId.HasValue ? await _unitOfWork.DrugDosageFormRepository.GetByIdAsync(request.DosageFormTypeId.Value, cancellationToken) : drug.DosageFormType
            );

            await _unitOfWork.DrugRepository.UpdateAsync(drug, cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }
        protected override IAggregateRoot? GetAggregateRoot(Result<Unit, IDomainError> result)
        {
            // Return null or the drug aggregate root if needed
            return null;
        }
    }
}
