using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Entities
{
    public class DrugEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string SKU { get; set; } = null!;
        public Guid DosageFormId { get; set; }
        public Guid DrugCategoryId { get; set; }
        public bool IsActive { get; set; } = true;

        public DosageFormEntity DosageForm { get; set; } = null!;
        public DrugCategoryEntity DrugCategory { get; set; } = null!;
        public ICollection<LotEntity> Lots { get; set; } = new List<LotEntity>();
        public ICollection<MedicationOrderItemEntity> MedicationOrderItems { get; set; } = new List<MedicationOrderItemEntity>();
    }
}
