using CSharpFunctionalExtensions;
using MediatR;
using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Application.Services;
using Medication_Order_Service.Domain.Accounts;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : CommandHandlerBase<CreateAccountCommand, Unit>
    {
        private readonly IPasswordWrapper _passwordWrapper;
        public CreateAccountCommandHandler(IUnitOfWork unitOfWork, IPasswordWrapper passwordWrapper) : base(unitOfWork)
        {
            _passwordWrapper = passwordWrapper;
        }
        protected async override Task<Result<Unit, IDomainError>> ExecuteAsync(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var existedAccount = await _unitOfWork.AccountRepository.GetAccountExist(request, cancellationToken);

            if (existedAccount != null)
            {
                return Result.Failure<Unit, IDomainError>(DomainError.Conflict("Account with information above already exists."));
            }

            var roleExists = await _unitOfWork.RoleRepository.GetByIdAsync(request.RoleId, cancellationToken);

            if (roleExists == null)
            {
                return Result.Failure<Unit, IDomainError>(DomainError.Conflict($"Role with id {request.RoleId} above not exist."));
            }

            var account = Account.Create(
                request.FullName,
                request.Email,
                roleExists,
                request.UserName,
                request.PhoneNumber
            );

            var hashedPassword = _passwordWrapper.HashPassword(account, request.Password);

            account.HashPassword(hashedPassword);

            await _unitOfWork.AccountRepository.AddAsync(account, cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }

        protected override IAggregateRoot? GetAggregateRoot(Result<Unit, IDomainError> result)
        {
            throw new NotImplementedException();
        }
    }
}
