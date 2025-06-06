using CSharpFunctionalExtensions;
using MediatR;
using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Errors;
using Medication_Order_Service.Domain.Drugs;
using Medication_Order_Service.Domain.Drugs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Drugs.Commands.CreateDrug
{
    public class CreateDrugCommandHandler : CommandHandlerBase<CreateDrugCommand, Unit>
    {
        public CreateDrugCommandHandler(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
        protected override async Task<Result<Unit, IDomainError>> ExecuteAsync(
            CreateDrugCommand request, CancellationToken cancellationToken)
        {
            var drugCategoryExist = await _unitOfWork.DrugCategoryRepository.GetByIdAsync(request.DrugCategoryId, cancellationToken);
            if(drugCategoryExist is null)
            {
                return Result.Failure<Unit, IDomainError>(DomainError.NotFound($"Drug category with id {request.DrugCategoryId} not found."));
            }

            var dosageFormExist = await _unitOfWork.DrugDosageFormRepository.GetByIdAsync(request.DosageFormTypeId, cancellationToken);
            if (dosageFormExist is null)
            {
                return Result.Failure<Unit, IDomainError>(DomainError.NotFound($"Dosage form with id {request.DosageFormTypeId} not found."));
            }

            var drug = Drug.Create(
                request.Name,
                request.Description,
                request.Price,
                request.SKU,
                drugCategoryExist,
                dosageFormExist
            );

            await _unitOfWork.DrugRepository.AddAsync(drug, cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }
        protected override IAggregateRoot? GetAggregateRoot(Result<Unit, IDomainError> result)
        {
            // Return null or the drug aggregate root if needed
            return null;
        }
    }
}
