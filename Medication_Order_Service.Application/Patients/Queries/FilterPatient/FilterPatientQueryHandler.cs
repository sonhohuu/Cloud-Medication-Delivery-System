using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Errors;
using Medication_Order_Service.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Patients.Queries.FilterPatient
{
    public class FilterPatientQueryHandler : IQueryHandler<FilterPatientQuery, PagedList<Patient>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public FilterPatientQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<Result<PagedList<Patient>, IDomainError>> Handle(FilterPatientQuery request, CancellationToken cancellationToken)
        {
            //using (var _unitOfWork = await unitOfWork.Create())
            //{
            var result = await _unitOfWork.PatientRepository.FilterPatientAsync(request);
            //}

            return Result.Success<PagedList<Patient>, IDomainError>(result);
        }
    }
}
