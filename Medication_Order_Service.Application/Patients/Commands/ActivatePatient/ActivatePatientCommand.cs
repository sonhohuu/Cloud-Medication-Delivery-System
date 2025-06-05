using MediatR;
using Medication_Order_Service.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Patients.Commands.ActivatePatient
{
    public class ActivatePatientCommand : ICommand<Unit>
    {
        public Guid Id { get; set; }
    }
}
