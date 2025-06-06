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
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommandHandler : CommandHandlerBase<UpdatePatientCommand, Unit>
    {
        public UpdatePatientCommandHandler(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
        protected async override Task<Result<Unit, IDomainError>> ExecuteAsync(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _unitOfWork.PatientRepository.GetByIdAsync(request.Id, cancellationToken);
            if (patient == null)
            {
                throw new Exception($"Patient with ID {request.Id} not found.");
            }

            patient.Update(
                request.FullName,
                request.DateOfBirth,
                request.Gender,
                request.Phone,
                request.Email,
                request.Address,
                request.Allergies,
                request.Weight
            );

            await _unitOfWork.PatientRepository.UpdateAsync(patient, cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }

        protected override IAggregateRoot? GetAggregateRoot(Result<Unit, IDomainError> result)
        {
            throw new NotImplementedException();
        }
    }
}
