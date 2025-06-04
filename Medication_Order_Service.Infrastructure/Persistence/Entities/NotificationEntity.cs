using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Entities
{
    public class NotificationEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Content { get; set; } = null!;
        public bool IsRead { get; set; } = false;
        public Guid AssignedToAccountId { get; set; }
        public virtual AccountEntity AssignedToAccount { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
