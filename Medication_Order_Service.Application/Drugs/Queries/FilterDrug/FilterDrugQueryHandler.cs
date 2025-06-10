using CSharpFunctionalExtensions;
using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Errors;
using Medication_Order_Service.Domain.Drugs;
using Medication_Order_Service.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Drugs.Queries.FilterDrug
{
    public class FilterDrugQueryHandler : IQueryHandler<FilterDrugQuery, PagedList<Drug>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public FilterDrugQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<Result<PagedList<Drug>, IDomainError>> Handle(FilterDrugQuery request, CancellationToken cancellationToken)
        {
            //using (var _unitOfWork = await unitOfWork.Create())
            //{
            var result = await _unitOfWork.DrugRepository.FilterDrugAsync(request);
            //}

            return Result.Success<PagedList<Drug>, IDomainError>(result);
        }
    }
}
