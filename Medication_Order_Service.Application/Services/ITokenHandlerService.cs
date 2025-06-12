using Medication_Order_Service.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Services
{
    public interface ITokenHandlerService
    {
        public string GenerateJwtToken(Account account);
        public string GenerateRefreshToken(Guid accountId);
        public ClaimsPrincipal? ValidateRefreshToken(string token);
    }
}
