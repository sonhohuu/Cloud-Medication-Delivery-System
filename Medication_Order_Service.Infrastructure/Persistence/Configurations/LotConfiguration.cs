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
    public class LotConfiguration : IEntityTypeConfiguration<LotEntity>
    {
        public void Configure(EntityTypeBuilder<LotEntity> builder)
        {
            builder.ToTable("Lot");
            builder.HasKey(x => x.Id);

            builder.HasOne<DrugEntity>()
                   .WithMany()
                   .HasForeignKey(x => x.DrugId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<StorageLocationEntity>()
                   .WithMany()
                   .HasForeignKey(x => x.StorageLocationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
