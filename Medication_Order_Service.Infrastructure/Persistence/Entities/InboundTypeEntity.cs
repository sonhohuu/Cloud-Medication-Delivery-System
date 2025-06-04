using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Entities
{
    public class InboundTypeEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<InboundEntity> Inbounds { get; set; } = new List<InboundEntity>();
    }
}
