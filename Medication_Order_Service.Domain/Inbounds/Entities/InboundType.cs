using Medication_Order_Service.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.Inbounds.Entities
{
    public class InboundType : Entity<InboundType>
    {
        public string Name { get; private set; }
        private InboundType(Id<InboundType> id) : base(id)
        {
        }
        public static InboundType Create(string name)
        {
            return new InboundType(Id<InboundType>.New())
            {
                Name = name
            };
        }
        public void Update(string? name, string? description)
        {
            if (name != null)
            {
                Name = name;
            }
        }
    }
}
