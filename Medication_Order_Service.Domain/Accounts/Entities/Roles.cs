using Medication_Order_Service.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.Accounts.Entities
{
    public class Roles : Entity<Roles>
    {
        public string Name { get; private set; }
        private Roles(Id<Roles> id) : base(id) { }
        public static Roles Create(string name, string description)
        {
            return new Roles(Id<Roles>.New())
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
