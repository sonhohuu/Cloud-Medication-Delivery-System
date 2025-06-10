using CSharpFunctionalExtensions;
using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Application.Drugs.Queries.FilterDrug;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Errors;
using Medication_Order_Service.Domain.Drugs;
using Medication_Order_Service.Domain.MedicationOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.MedicationOrders.Queries.FilterMedicationOrder
{
    public class FilterMedicationOrderQueryHandler : IQueryHandler<FilterMedicationOrderQuery, PagedList<MedicationOrder>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public FilterMedicationOrderQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<Result<PagedList<MedicationOrder>, IDomainError>> Handle(FilterMedicationOrderQuery request, CancellationToken cancellationToken)
        {
            //using (var _unitOfWork = await unitOfWork.Create())
            //{
            var result = await _unitOfWork.MedicationOrderRepository.FilterMedicationOrderAsync(request);
            //}

            return Result.Success<PagedList<MedicationOrder>, IDomainError>(result);
        }
    }
}
