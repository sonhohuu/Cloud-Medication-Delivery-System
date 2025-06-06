using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Errors;
using Medication_Order_Service.Domain.MedicationOrders;
using Medication_Order_Service.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.MedicationOrders.Commands.RegisterMedicationOrder
{
    public class RegisterMedicationOrderCommandHandler : CommandHandlerBase<RegisterMedicationOrderCommand, Unit>
    {
        private readonly IMapper _mapper;
        public RegisterMedicationOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        protected override async Task<Result<Unit, IDomainError>> ExecuteAsync(RegisterMedicationOrderCommand request, CancellationToken cancellationToken)
        {
            var patient = await _unitOfWork.PatientRepository.GetByIdAsync(request.patientId, cancellationToken);
            if (patient is null)
            {
                return Result.Failure<Unit, IDomainError>(DomainError.NotFound($"Patient with id {request.patientId}"));
            }
            if (!patient.IsActive)
            {
                return Result.Failure<Unit, IDomainError>(DomainError.Conflict($"Can't register patient nơt active"));
            }
            if (patient.IsTreating)
            {
                return Result.Failure<Unit, IDomainError>(DomainError.Conflict($"Can't register patient on treating"));
            }

            MedicationOrder _createdOrder = MedicationOrder.Create(patient.Id, Guid.Parse("550E8400-E29B-41D4-A716-446655440000"), request.waitingNumber, request.medicationRoom, request.priority, request.note);
            patient.UpdateOnTreating();
            await _unitOfWork.PatientRepository.UpdateAsync(patient, cancellationToken);
            await _unitOfWork.MedicationOrderRepository.AddAsync(_createdOrder, cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }

        protected override IAggregateRoot? GetAggregateRoot(Result<Unit, IDomainError> result)
        {
            return null;
        }
    }
}
