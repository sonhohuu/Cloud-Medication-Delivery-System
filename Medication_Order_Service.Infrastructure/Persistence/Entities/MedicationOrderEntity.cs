using Medication_Order_Service.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Entities
{
    public class MedicationOrderEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public PatientEntity Patient { get; set; } = null!;
        public Guid? DoctorId { get; set; }
        public AccountEntity Doctor { get; set; } = null!;
        public MedicationOrderStatus Status { get; set; }
        public Guid CreatedByAccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Notes { get; set; }
        public string? ReasonCancelled { get; set; }
        public int WaitingNumber { get; set; }
        public MedicationOrderRoom MedicationRoom { get; set; }
        public MedicationOrderPriority Priority { get; set; }
        public AccountEntity CreatedByAccount { get; set; } = null!;
        public ICollection<MedicationOrderItemEntity> Items { get; set; } = new List<MedicationOrderItemEntity>();
        public BillEntity? Bill { get; set; }
    }
}
