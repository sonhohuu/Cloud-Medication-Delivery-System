using Medication_Order_Service.Infrastructure.Persistence.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Entities
{
    public class MedicationOrderEntity
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public virtual PatientEntity Patient { get; set; } = null!;
        public Guid DoctorId { get; set; }
        public virtual AccountEntity Doctor { get; set; } = null!;
        public MedicationOrderStatus Status { get; set; }
        public Guid CreatedByAccountId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
