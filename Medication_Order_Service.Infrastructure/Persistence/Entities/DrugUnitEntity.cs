using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Entities
{
    public class DrugUnitEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DrugId { get; set; }
        public string UnitName { get; set; } = null!;
        public int? ParentUnitId { get; set; }
        public int ConversionRate { get; set; }
        public bool IsBaseUnit { get; set; }
        public DrugEntity Drug { get; set; } = null!;
        public DrugUnitEntity? ParentUnit { get; set; }
    }
}
