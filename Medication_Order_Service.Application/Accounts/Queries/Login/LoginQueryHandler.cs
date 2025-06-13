using CSharpFunctionalExtensions;
using MediatR;
using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Application.Services;
using Medication_Order_Service.Domain.Accounts;
using Medication_Order_Service.Domain.Common.Errors;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Accounts.Queries.Login
{
    public class LoginQueryHandler : IQueryHandler<LoginQuery, AccountLoginResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordWrapper _passwordHasher;
        private readonly ITokenHandlerService _tokenHandlerService;
        public LoginQueryHandler(IUnitOfWork unitOfWork, IPasswordWrapper passwordHasher, ITokenHandlerService tokenHandlerService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
            _tokenHandlerService = tokenHandlerService ?? throw new ArgumentNullException(nameof(tokenHandlerService));
        }
        public async Task<Result<AccountLoginResponse, IDomainError>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var accountExist = await _unitOfWork.AccountRepository.Login(request, cancellationToken);

            if(accountExist is null)
            {
                return Result.Failure<AccountLoginResponse, IDomainError>(DomainError.Conflict($"Account with username or email above {request.UserNameOrEmail} not exist"));
            }

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(accountExist, accountExist.PasswordHash , request.Password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
                return Result.Failure<AccountLoginResponse, IDomainError>(DomainError.Conflict($"Incorrect Password: {request.Password}"));

            return Result.Success<AccountLoginResponse, IDomainError>(new AccountLoginResponse
            {
                Token = _tokenHandlerService.GenerateJwtToken(accountExist),
                RefreshToken = _tokenHandlerService.GenerateRefreshToken(accountExist.Id.Value),
                Role = accountExist.Roles.Name
            });
        }
    }
}
