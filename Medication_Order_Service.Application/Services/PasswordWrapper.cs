using Medication_Order_Service.Domain.Accounts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Services
{
    public class PasswordWrapper : IPasswordWrapper
    {
        private readonly IPasswordHasher<Account> _passwordHelper;

        public PasswordWrapper(IPasswordHasher<Account> passwordHelper)
        {
            _passwordHelper = passwordHelper;
        }

        public string HashPassword(Account account, string password)
            => _passwordHelper.HashPassword(account, password);

        public string HashValue(string value)
            => _passwordHelper.HashPassword(null, value);

        public PasswordVerificationResult VerifyHashedPassword(Account account, string hashedPassword, string password)
            => _passwordHelper.VerifyHashedPassword(account, hashedPassword, password);

        public PasswordVerificationResult VerifyHashedValue(string hashedValue, string value)
            => _passwordHelper.VerifyHashedPassword(null, hashedValue, value);
    }
}
