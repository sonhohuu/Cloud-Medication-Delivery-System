using MediatR;
using Medication_Order_Service.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Medication_Order_Service.Application.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommand : ICommand<Unit>
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Allergies { get; set; }
        public decimal? Weight { get; set; }
    }
}
