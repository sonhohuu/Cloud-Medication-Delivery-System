using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Entities
{
    public class StorageLocationEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Sheft { get; set; } = null!;
        public string TemperatureRange { get; set; } = null!;
        public string HumidityRange { get; set; } = null!;
        public ICollection<LotEntity> Lots { get; set; } = new List<LotEntity>();
        public ICollection<LotTransferEntity> LotTransferFroms { get; set; } = new List<LotTransferEntity>();
        public ICollection<LotTransferEntity> LotTransferTos { get; set; } = new List<LotTransferEntity>();
    }
}
