using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.MedicationOrders.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Allergies { get; set; }
        public decimal Weight { get; set; }
        public bool IsTreating { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
