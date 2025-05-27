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
    public class InboundTypeConfiguration : IEntityTypeConfiguration<InboundTypeEntity>
    {
        public void Configure(EntityTypeBuilder<InboundTypeEntity> builder)
        {
            builder.ToTable("InboundType");
            builder.HasKey(x => x.Id);
        }
    }
}
