using CSharpFunctionalExtensions;
using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Domain.Common.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Accounts.Queries.Login
{
    public class LoginQuery : IQuery<AccountLoginResponse>
    {
        public string UserNameOrEmail { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
