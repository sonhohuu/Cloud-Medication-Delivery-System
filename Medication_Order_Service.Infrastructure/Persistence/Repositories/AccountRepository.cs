using AutoMapper;
using Azure.Core;
using MediatR;
using Medication_Order_Service.Application.Accounts.Commands.CreateAccount;
using Medication_Order_Service.Application.Accounts.Queries.Login;
using Medication_Order_Service.Application.Repositories;
using Medication_Order_Service.Domain.Accounts;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Patients;
using Medication_Order_Service.Infrastructure.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Repositories
{
    public class AccountRepository : RepositoryBase<Account, AccountEntity>, IAccountRepository
    {
        public AccountRepository(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Account?> GetAccountExist(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Set<AccountEntity>()
                .AsNoTracking()
                .Where(a => a.UserName == request.UserName || a.Email == request.Email || a.PhoneNumber == request.PhoneNumber)
                .FirstOrDefaultAsync(cancellationToken);

            return entity != null ? _mapper.Map<Account>(entity) : null;
        }

        public async Task<Account?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.Set<AccountEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return entity != null ? _mapper.Map<Account>(entity) : null;
        }

        public async Task<Account> Login(LoginQuery query, CancellationToken cancellationToken)
        {
            var entity = await _context.Set<AccountEntity>()
                .AsNoTracking()
                .Include(a => a.Role)
                .FirstOrDefaultAsync(a => a.UserName == query.UserNameOrEmail || a.Email == query.UserNameOrEmail);

            return entity != null ? _mapper.Map<Account>(entity) : null;
        }
    }
}
