using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Entities
{
    public class AccountEntity : IdentityUser<Guid>
    {
        public string FullName { get; set; } = null!;
        public bool Status { get; set; } // Active or not

        public int RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Role Role { get; set; } = null!;
        public ICollection<AuditLogEntity> AuditLogs { get; set; } = new List<AuditLogEntity>();
        public ICollection<NotificationEntity> Notifications { get; set; } = new List<NotificationEntity>();
        public ICollection<MedicationOrderEntity> MedicationOrdersCreated { get; set; } = new List<MedicationOrderEntity>();
        public ICollection<MedicationOrderEntity> MedicationOrdersAsDoctor { get; set; } = new List<MedicationOrderEntity>();
        public ICollection<InboundEntity> Inbounds { get; set; } = new List<InboundEntity>();
    }
}
