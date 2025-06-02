using CSharpFunctionalExtensions;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Errors;
using Medication_Order_Service.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Abstractions
{
    public abstract class CommandHandlerBase<TCommand, TResponse> : ICommandHandler<TCommand, TResponse>
     where TCommand : ICommand<TResponse>
     where TResponse : notnull
    {
        //private readonly IDomainEventDispatcher _domainEventDispatcher;
        protected readonly IUnitOfWork _unitOfWork;

        protected CommandHandlerBase(
            //IDomainEventDispatcher domainEventDispatcher,
            IUnitOfWork unitOfWork)
        {
            //_domainEventDispatcher = domainEventDispatcher;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<TResponse, IDomainError>> Handle(TCommand request, CancellationToken cancellationToken)
        {

            // Step 1: Execute core operation
            var operationResult = await ExecuteAsync(request, cancellationToken);
            if (!operationResult.IsSuccess)
            {
                return operationResult; // Return failure result
            }

            // Step 2: Commit Unit of Work
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            // Step 3: Dispatch Domain Events
            //var aggregateRoot = GetAggregateRoot(operationResult);
            //if (aggregateRoot != null)
            //{
            //    var domainEvents = aggregateRoot.PopDomainEvents();
            //    await DispatchDomainEventsAsync(domainEvents, cancellationToken);
            //}

            // Step 4: Return Result
            return operationResult;


        }

        /// <summary>
        /// Executes the core operation logic for the command.
        /// </summary>
        protected abstract Task<Result<TResponse, IDomainError>> ExecuteAsync(TCommand request, CancellationToken cancellationToken);

        /// <summary>
        /// Extracts the aggregate root for dispatching domain events.
        /// </summary>
        protected abstract IAggregateRoot? GetAggregateRoot(Result<TResponse, IDomainError> result);

        /// <summary>
        /// Manually dispatches a collection of domain events.
        /// </summary>
        //protected async Task DispatchDomainEventsAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken)
        //{
        //    if (domainEvents == null) return;
        //    await _domainEventDispatcher.DispatchAsync(domainEvents, cancellationToken);
        //}
    }
}