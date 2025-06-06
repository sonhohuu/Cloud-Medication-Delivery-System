using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.Drugs.Entities
{
    public class DosageForm :Entity<DosageForm>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        private DosageForm(Id<DosageForm> id) : base(id)
        {
        }
        public static DosageForm Create(string name, string description)
        {
            return new DosageForm(Id<DosageForm>.New())
            {
                Name = name,
                Description = description
            };
        }
        public void Update(string? name, string? description)
        {
            if (name != null)
            {
                name.EnsureNonEmpty(nameof(name));
                Name = name;
            }
            if (description != null)
            {
                description.EnsureNonEmpty(nameof(description));
                Description = description;
            }
        }

    }
}
