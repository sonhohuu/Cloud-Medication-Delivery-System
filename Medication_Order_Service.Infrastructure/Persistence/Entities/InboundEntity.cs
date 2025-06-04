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
    public class InboundEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string InboundCode { get; set; } = null!;
        public string Note { get; set; } = null!;
        public Guid SupplierId { get; set; }
        public Guid InboundTypeId { get; set; }
        public InboundStatus Status { get; set; }
        public Guid CreatedByAccountId { get; set; }
        public DateTime CreatedAt { get; set; }

        public SupplierEntity Supplier { get; set; } = null!;
        public InboundTypeEntity InboundType { get; set; } = null!;
        public AccountEntity CreatedByAccount { get; set; } = null!;
        public ICollection<InboundDetailEntity> Details { get; set; } = new List<InboundDetailEntity>();
    }
}
