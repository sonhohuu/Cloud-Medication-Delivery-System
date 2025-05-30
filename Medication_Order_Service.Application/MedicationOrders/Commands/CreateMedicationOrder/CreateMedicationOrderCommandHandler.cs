using CSharpFunctionalExtensions;
using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Errors;
using Medication_Order_Service.Domain.MedicationOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.MedicationOrders.Commands.CreateMedicationOrder
{
    public class CreateMedicationOrderCommandHandler : CommandHandlerBase<CreateMedicationOrderCommand, int>
    {
        private readonly IMedicationOrderRepository _medicationOrderRepository;
        private MedicationOrder? _createdOrder;

        public CreateMedicationOrderCommandHandler(
            IMedicationOrderRepository medicationOrderRepository,
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _medicationOrderRepository = medicationOrderRepository;
        }

        protected override async Task<Result<int, IDomainError>> ExecuteAsync(CreateMedicationOrderCommand request, CancellationToken cancellationToken)
        {
            Patient patient = Patient.Create(request.patient.FullName, request.patient.DateOfBirth, request.patient.Gender, request.patient.Phone, request.patient.Email, request.patient.Address, request.patient.Allergies, request.patient.Weight);
            _createdOrder = MedicationOrder.Create(patient, Guid.Parse("3f8e4b2a-9c1d-4e7b-a2f5-6d8c0e3a7b9f"), request.waitingNumber, request.medicationRoom, request.priority, request.note);
            await _medicationOrderRepository.CreateAsync(_createdOrder);
            return Result.Success<int, IDomainError>(1);
        }

        protected override IAggregateRoot? GetAggregateRoot(Result<int, IDomainError> result)
        {
            throw new NotImplementedException();
        }
    }
}
