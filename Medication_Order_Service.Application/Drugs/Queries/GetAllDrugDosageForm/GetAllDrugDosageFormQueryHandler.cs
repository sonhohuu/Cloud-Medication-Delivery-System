using AutoMapper;
using CSharpFunctionalExtensions;
using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Application.Drugs.Queries.GetAllDrugCategory;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Common.Errors;
using Medication_Order_Service.Domain.Drugs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Drugs.Queries.GetAllDrugDosageForm
{
    public class GetAllDrugDosageFormQueryHandler : IQueryHandler<GetAllDrugDosageFormQuery, List<DosageForm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllDrugDosageFormQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Result<List<DosageForm>, IDomainError>> Handle(GetAllDrugDosageFormQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DrugDosageFormRepository.GetAllAsync(cancellationToken)
                .ContinueWith(task => Result.Success<List<DosageForm>, IDomainError>(task.Result), cancellationToken);
        }
    }
}
