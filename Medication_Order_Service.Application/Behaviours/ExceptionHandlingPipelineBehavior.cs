using CSharpFunctionalExtensions;
using MediatR;
using Medication_Order_Service.Domain.Common.Errors;
using Medication_Order_Service.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Behaviours
{
    //public class ExceptionHandlingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    // where TRequest : notnull, IRequest<TResponse>
    // where TResponse : notnull
    //{
    //    public async Task<TResponse> Handle(
    //        TRequest request,
    //        RequestHandlerDelegate<TResponse> next,
    //        CancellationToken cancellationToken)
    //    {
    //        try
    //        {
    //            // Proceed to the next behavior or actual handler
    //            return await next();
    //        }
    //        catch (ValidationException ex)
    //        {
    //            // Handle validation exceptions by returning a DomainError.Validation
    //            var domainError = DomainError.Validation(ex.Message, ex.Errors.ToList());
    //            var failureResult = Result.Failure<Guid, IDomainError>(domainError);

    //            if (failureResult is TResponse response)
    //            {
    //                return response;
    //            }

    //            throw new InvalidCastException("Failed to cast validation error result to the expected TResponse type.");
    //        }
    //        catch (Exception ex)
    //        {
    //            // Handle unexpected exceptions by returning a DomainError.Unexpected
    //            var domainError = DomainError.UnExpected($"An unexpected error occurred: {ex.Message}");
    //            var failureResult = Result.Failure<Guid, IDomainError>(domainError);

    //            if (failureResult is TResponse response)
    //            {
    //                return response;
    //            }

    //            throw new InvalidCastException("Failed to cast unexpected error result to the expected TResponse type.");
    //        }
    //    }
    //}
}
