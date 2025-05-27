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
    public class InboundConfiguration : IEntityTypeConfiguration<InboundEntity>
    {
        public void Configure(EntityTypeBuilder<InboundEntity> builder)
        {
            builder.ToTable("Inbound");
            builder.HasKey(x => x.Id);

            builder.HasOne<SupplierEntity>()
                   .WithMany()
                   .HasForeignKey(x => x.SupplierId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<InboundTypeEntity>()
                   .WithMany()
                   .HasForeignKey(x => x.InboundTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<AccountEntity>()
                   .WithMany(x => x.Inbounds)
                   .HasForeignKey(x => x.CreatedByAccountId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
