using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Entities
{
    public class AccountEntity : IdentityUser<Guid>
    {
        public string FullName { get; set; } = null!;
        public bool Status { get; set; } // Active or not

        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
