using Medication_Order_Service.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Configurations
{
    public class InboundDetailConfiguration : IEntityTypeConfiguration<InboundDetailEntity>
    {
        public void Configure(EntityTypeBuilder<InboundDetailEntity> builder)
        {
            builder.ToTable("InboundDetail");
            builder.HasKey(x => x.Id);

        }
    }
}
