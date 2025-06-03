using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Application.MedicationOrders.Commands.RegisterMedicationOrder;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Errors;
using Medication_Order_Service.Domain.MedicationOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.MedicationOrders.Commands.VerifiedMedicationOrder
{
    public class DispensedMedicationOrderCommandHandler : CommandHandlerBase<DispensedMedicationOrderCommand, Unit>
    {
        private readonly IMapper _mapper;
        private MedicationOrder? verifiedOrder;
        public DispensedMedicationOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        protected override async Task<Result<Unit, IDomainError>> ExecuteAsync(DispensedMedicationOrderCommand request, CancellationToken cancellationToken)
        {
            var doctorId = Guid.Parse("3f8e4b2a-9c1d-4e7b-a2f5-6d8c0e3a7b9f");
            verifiedOrder?.VerifyByDoctor(doctorId, request?.note);

            await _unitOfWork.MedicationOrderRepository.UpdateAsync(verifiedOrder, cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }

        protected override IAggregateRoot? GetAggregateRoot(Result<Unit, IDomainError> result)
        {
            return null;
        }
    }
}
