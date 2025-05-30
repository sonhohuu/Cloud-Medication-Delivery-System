using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.MedicationOrders
{
    public class Patient : Entity<Patient>
    {
        public string FullName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Gender { get; private set; }
        public string? Phone { get; private set; }
        public string? Email { get; private set; }
        public string? Address { get; private set; }
        public string? Allergies { get; private set; }
        public decimal Weight { get; private set; }
        public bool IsTreating { get; private set; }

        private Patient(string fullName, DateTime dateOfBirth, string gender, string? phone, string? email, string? address, string? allergies, decimal weight)
        {
            FullName.EnsureNonEmpty(nameof(fullName));
            DateOfBirth.EnsureNotDefault(nameof(dateOfBirth));
            Gender.EnsureNonEmpty(nameof(gender));
            Weight.EnsureNonNegative(nameof(weight));
        }

        public static Patient Create(string fullName, DateTime dateOfBirth, string gender, string? phone, string? email, string? address, string? allergies, decimal weight)
        {
            return new Patient(fullName, dateOfBirth, gender, phone, email, address, allergies, weight);
        }

        public void UpdateOnTreating()
        {
            IsTreating = true;
        }

        public void UpdateOffTreating()
        {
            IsTreating = false;
        }
    }
}
