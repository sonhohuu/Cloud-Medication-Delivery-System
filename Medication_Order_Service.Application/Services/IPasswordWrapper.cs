using Medication_Order_Service.Domain.Accounts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Services
{
    public interface IPasswordWrapper
    {
        string HashPassword(Account account, string password);
        PasswordVerificationResult VerifyHashedPassword(Account account, string hashedPassword, string password);
        string HashValue(string value);
        PasswordVerificationResult VerifyHashedValue(string hashedValue, string value);
    }
}
