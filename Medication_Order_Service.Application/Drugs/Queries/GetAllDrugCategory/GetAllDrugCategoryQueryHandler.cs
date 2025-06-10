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

namespace Medication_Order_Service.Application.Drugs.Queries.GetAllDrugCategory
{
    public class GetAllDrugCategoryQueryHandler : IQueryHandler<GetAllDrugCategoryQuery, List<DrugCategory>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllDrugCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Result<List<DrugCategory>, IDomainError>> Handle(GetAllDrugCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DrugCategoryRepository.GetAllAsync(cancellationToken)
                .ContinueWith(task => Result.Success<List<DrugCategory>, IDomainError>(task.Result), cancellationToken);
        }
    }
}
