using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Entities
{
    public class AuditLogEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public virtual AccountEntity Account { get; set; } = null!;
        public string Action { get; set; } = null!;
        public string Resource { get; set; } = null!;
        public string Payload { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}
