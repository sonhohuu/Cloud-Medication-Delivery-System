using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Domain.MedicationOrders
{
    public class Patient /*: Entity<Patient>*/
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
        private Patient() { } // Private constructor for EF Core or other ORM usage

        private Patient(string fullName, DateTime dateOfBirth, string gender, string? phone, string? email, string? address, string? allergies, decimal weight)
        {
            fullName.EnsureNonEmpty(nameof(fullName));
            dateOfBirth.EnsureNotDefault(nameof(dateOfBirth));
            gender.EnsureNonEmpty(nameof(gender));
            weight.EnsureNonNegative(nameof(weight));

            FullName = fullName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Phone = phone;
            Email = email;
            Address = address;
            Allergies = allergies;
            Weight = weight;
            IsTreating = false; // Initialize default value
        }

        public static Patient Create(string fullName, DateTime dateOfBirth, string gender, string? phone, string? email, string? address, string? allergies, decimal weight)
        {
            return new Patient(fullName, dateOfBirth, gender, phone, email, address, allergies, weight);
        }

        public static Patient UpdateByDocter(string? allergies)
        {
            return new Patient
            {
                Allergies = allergies
            };
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
