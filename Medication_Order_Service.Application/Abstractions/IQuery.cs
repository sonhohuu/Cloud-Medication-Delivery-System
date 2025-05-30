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
    public interface IRequestBase { }
    public interface IQuery<TResponse> : IRequestBase, IRequest<Result<TResponse, IDomainError>>
        where TResponse : notnull
    { }

    public interface IQuery : IRequestBase, IRequest<Result>
    { }
}
