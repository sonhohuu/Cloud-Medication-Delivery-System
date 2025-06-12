using Medication_Order_Service.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.Accounts.Entities
{
    public class Role : Entity<Role>
    {
        public string Name { get; private set; }
        private Role(Id<Role> id) : base(id) { }
        public static Role Create(string name, string description)
        {
            return new Role(Id<Role>.New())
            {
                Name = name
            };
        }
        public void Update(string? name)
        {
            if (name != null)
            {
                Name = name;
            }
        }
    }
}
