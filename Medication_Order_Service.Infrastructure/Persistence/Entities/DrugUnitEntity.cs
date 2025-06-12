using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Entities
{
    public class DrugUnitEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string UnitName { get; set; } = null!;
        public Guid? ParentUnitId { get; set; }
        public int ConversionRate { get; set; }
        public bool IsBaseUnit { get; set; }
        public DrugUnitEntity? ParentUnit { get; set; }
    }
}
