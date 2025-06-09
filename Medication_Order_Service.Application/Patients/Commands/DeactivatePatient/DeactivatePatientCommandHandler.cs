using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Application.Patients.Commands.AddPatient;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Patients.Commands.DeactivatePatient
{
    public class DeactivatePatientCommandHandler : CommandHandlerBase<DeactivatePatientCommand, Unit>
    {
        public DeactivatePatientCommandHandler(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        protected async override Task<Result<Unit, IDomainError>> ExecuteAsync(DeactivatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _unitOfWork.PatientRepository.GetByIdAsync(request.Id, cancellationToken);
            if (patient == null)
            {
                return Result.Failure<Unit, IDomainError>(DomainError.NotFound());
            }

            patient.Deactivate();
            await _unitOfWork.PatientRepository.UpdateAsync(patient, cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }

        protected override IAggregateRoot? GetAggregateRoot(Result<Unit, IDomainError> result)
        {
            throw new NotImplementedException();
        }
    }
}
