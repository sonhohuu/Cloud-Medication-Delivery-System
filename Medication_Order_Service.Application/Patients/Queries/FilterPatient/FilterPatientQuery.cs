using Medication_Order_Service.Application.Abstractions;
using Medication_Order_Service.Domain.Common;
using Medication_Order_Service.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Application.Patients.Queries.FilterPatient
{
    public class FilterPatientQuery : IQuery<PagedList<Patient>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? FullName { get; set; }
        public bool? IsActive { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
