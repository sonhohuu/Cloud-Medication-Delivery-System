using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Errors;
using Medication_Order_Service.Domain.MedicationOrders.Entities;
using Medication_Order_Service.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Patients.Commands.AddPatient
{
    public class AddPatientCommandHandler : CommandHandlerBase<AddPatientCommand, Unit>
    {
        private readonly IMapper _mapper;

        public AddPatientCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        protected override async Task<Result<Unit, IDomainError>> ExecuteAsync(
            AddPatientCommand request, CancellationToken cancellationToken)
        {
            var patient = Patient.Create(
                request.FullName,
                request.DateOfBirth,
                request.Gender,
                request.Phone,
                request.Email,
                request.Address,
                request.Allergies,
                request.Weight
            );

            await _unitOfWork.PatientRepository.AddAsync(patient, cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }

        protected override IAggregateRoot? GetAggregateRoot(Result<Unit, IDomainError> result)
        {
            // Có thể trả về null hoặc order nếu cần raise domain events
            return null;
        }
    }
}
