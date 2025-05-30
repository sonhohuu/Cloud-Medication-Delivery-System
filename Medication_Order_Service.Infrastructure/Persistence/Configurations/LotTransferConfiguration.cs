using Medication_Order_Service.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence.Configurations
{
    public class LotTransferConfiguration : IEntityTypeConfiguration<LotTransferEntity>
    {
        public void Configure(EntityTypeBuilder<LotTransferEntity> builder)
        {
            builder.ToTable("LotTransfer");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.FromLocation)
                   .WithMany(a => a.LotTransferFroms)
                   .HasForeignKey(x => x.From)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ToLocation)
                   .WithMany(a => a.LotTransferTos)
                   .HasForeignKey(x => x.To)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
