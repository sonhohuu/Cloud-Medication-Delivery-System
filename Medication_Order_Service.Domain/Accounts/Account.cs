using Medication_Order_Service.Domain.Accounts.Entities;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.Accounts
{
    public class Account : AggregateRoot<Account>
    {
        public string FullName { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }
        public bool Status { get; private set; }
        public Roles Roles { get; private set; }
        public string Username { get; private set; }
        public bool EmailConfirmed { get; private set; }
        public string PhoneNumber { get; private set; }
        public string ConcurrencyStamp { get; private set; }
        public string SecurityStamp { get; private set; }
        private Account(Id<Account> id) : base(id)
        {
        }

        public static Account Create(string fullName, string email, Roles role, string username, string phoneNumber)
        {
            return new Account(Id<Account>.New())
            {
                FullName = fullName,
                Email = email,
                Roles = role,
                Username = username,
                PhoneNumber = phoneNumber,
                Status = true,
                EmailConfirmed = false
            };
        }

        public void HashPassword(string passwordHash)
        {
            passwordHash.EnsureNonEmpty(nameof(passwordHash));
            PasswordHash = passwordHash;
        }

        public void Activate()
        {
            if (Status) return;
            Status = true;
        }

        public void Deactivate()
        {
            if (!Status) return;
            Status = false;
        }

        public void ChangeEmail(string newEmail)
        {
            if (Email == newEmail) return;

            var oldEmail = Email;
            Email = newEmail;
            EmailConfirmed = false;
        }

        public void ConfirmEmail()
        {
            if (EmailConfirmed) return;

            EmailConfirmed = true;
        }
    }
}
