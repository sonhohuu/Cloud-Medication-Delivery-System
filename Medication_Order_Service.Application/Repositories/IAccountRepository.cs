using Medication_Order_Service.Application.Accounts.Commands.CreateAccount;
using Medication_Order_Service.Application.Accounts.Queries.Login;
using Medication_Order_Service.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Repositories
{
    public interface IAccountRepository : IAddRepository<Account>, 
        IUpdateRepository<Account>,
        IReadRepository<Account, Guid>
    {
        Task<Account?> GetAccountExist(CreateAccountCommand request, CancellationToken cancellationToken);
        Task<Account> Login(LoginQuery request, CancellationToken cancellationToken);
    }
}
