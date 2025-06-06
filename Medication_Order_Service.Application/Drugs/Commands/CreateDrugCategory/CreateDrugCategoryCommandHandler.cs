using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Common.Errors;
using Medication_Order_Service.Domain.Drugs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Drugs.Commands.CreateDrugCategory
{
    public class CreateDrugCategoryCommandHandler : ICommandHandler<CreateDrugCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateDrugCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<Result<Unit, IDomainError>> Handle(CreateDrugCategoryCommand request, CancellationToken cancellationToken)
        {
            var existingCategory = await _unitOfWork.DrugCategoryRepository.ExistsByNameAsync(request.Name, cancellationToken);

            if (existingCategory)
            {
                return Result.Failure<Unit, IDomainError>(DomainError.Conflict($"Drug category with name '{request.Name}' already exists."));
            }
            var drugCategory = DrugCategory.Create(request.Name, request.Description);

            await _unitOfWork.DrugCategoryRepository.AddAsync(drugCategory, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success<Unit, IDomainError>(Unit.Value);
        }
    }
}
