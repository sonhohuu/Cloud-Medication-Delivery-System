using AutoMapper;
using CSharpFunctionalExtensions;
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
    public class RegisterMedicationOrderCommandHandler : CommandHandlerBase<RegisterMedicationOrderCommand, Id<MedicationOrder>>
    {
        private readonly IMapper _mapper;
        public RegisterMedicationOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        protected override async Task<Result<Id<MedicationOrder>, IDomainError>> ExecuteAsync(RegisterMedicationOrderCommand request, CancellationToken cancellationToken)
        {
            //Patient patient = Patient.Create(request.patient.FullName, request.patient.DateOfBirth, request.patient.Gender, request.patient.Phone, request.patient.Email, request.patient.Address, request.patient.Allergies, request.patient.Weight);
            //MedicationOrder _createdOrder = MedicationOrder.Create(Guid.Parse("3f8e4b2a-9c1d-4e7b-a2f5-6d8c0e3a7b9f"), Guid.Parse("3f8e4b2a-9c1d-4e7b-a2f5-6d8c0e3a7b9f"), request.waitingNumber, request.medicationRoom, request.priority, request.note);
            //patient.UpdateOnTreating();
            //await _unitOfWork.MedicationOrderRepository.AddAsync(_createdOrder, cancellationToken);
            //return Result.Success<Id<MedicationOrder>, IDomainError>(_createdOrder.Id);
            return Result.Success<Id<MedicationOrder>, IDomainError>( new Id <MedicationOrder>());
        }

        protected override IAggregateRoot? GetAggregateRoot(Result<Id<MedicationOrder>, IDomainError> result)
        {
            return null;
        }
    }
}
