using CSharpFunctionalExtensions;
using MediatR;
using Medication_Order_Service.Domain.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Abstractions
{
    public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse, IDomainError>>
       where TRequest : IQuery<TResponse>
       where TResponse : notnull
    { }
}
