using Medication_Order_Service.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Configurations
{
    public class InventoryTransactionConfiguration : IEntityTypeConfiguration<InventoryTransactionEntity>
    {
        public void Configure(EntityTypeBuilder<InventoryTransactionEntity> builder)
        {
            builder.ToTable("InventoryTransaction");
            builder.HasKey(x => x.Id);
        }
    }
}
