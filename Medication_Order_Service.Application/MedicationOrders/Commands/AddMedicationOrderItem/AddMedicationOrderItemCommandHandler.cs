using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Errors;
using Medication_Order_Service.Domain.MedicationOrders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.MedicationOrders.Commands.AddMedicationOrderItem
{
    public class AddMedicationOrderItemCommandHandler : CommandHandlerBase<AddMedicationOrderItemCommand, Unit>
    {
        private readonly IMapper _mapper;

        public AddMedicationOrderItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        protected override async Task<Result<Unit, IDomainError>> ExecuteAsync(
            AddMedicationOrderItemCommand request, CancellationToken cancellationToken)
        {
            var medicationOrder = await _unitOfWork.MedicationOrderRepository.GetByIdAsync(request.MedicationOrderId, cancellationToken);
            if (medicationOrder == null)
                return Result.Failure<Unit, IDomainError>(DomainError.NotFound());

            // Loop through each item in the command and add it
            foreach (var itemReq in request.Items)
            {
                var drugActive = await _unitOfWork.DrugRepository.GetByIdAsync(itemReq.DrugId, cancellationToken);
                if (drugActive.IsActive)
                {
                    // Kiểm tra xem thuốc có đang hoạt động không
                    return Result.Failure<Unit, IDomainError>(DomainError.BadRequest($"Drug with ID {itemReq.DrugId} is not active "));
                }
                var item = MedicationOrderItem.Create(
                    itemReq.DrugId,
                    itemReq.Quantity,
                    itemReq.UnitPrice,
                    itemReq.Dosage,
                    itemReq.Frequency,
                    itemReq.Duration
                );

                medicationOrder?.AddMedicationItem(item);
            }

            var doctorId = Guid.Parse("550E8400-E29B-41D4-A716-446655440000");
            medicationOrder?.VerifyByDoctor(doctorId, request?.Note);

            await _unitOfWork.MedicationOrderRepository.UpdateAsync(medicationOrder, cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }

        protected override IAggregateRoot? GetAggregateRoot(Result<Unit, IDomainError> result)
        {
            // Có thể trả về null hoặc order nếu cần raise domain events
            return null;
        }
    }
}
