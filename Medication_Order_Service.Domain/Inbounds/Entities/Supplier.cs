using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Extensions;
using Medication_Order_Service.Domain.Drugs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.Inbounds.Entities
{
    public class Supplier : Entity<Supplier>
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string DocumentNumber { get; private set; }
        public bool Status { get; private set; }
        private Supplier(Id<Supplier> id) : base(id)
        {
        }
        public static Supplier Create(string name, string address, string phoneNumber, string documentNumber)
        {
            return new Supplier(Id<Supplier>.New())
            {
                Name = name,
                Address = address,
                PhoneNumber = phoneNumber,
                DocumentNumber = documentNumber,
                Status = true
            };
        }

        public void Update(string? name, string? address, string? phoneNumber, string? documentNumber)
        {
            if (name != null)
            {
                Name = name;
            }
            if (address != null)
            {
                Address = address;
            }
            if (phoneNumber != null)
            {
                PhoneNumber = phoneNumber;
            }
            if (documentNumber != null)
            {
                DocumentNumber = documentNumber;
            }
        }
    }
}
