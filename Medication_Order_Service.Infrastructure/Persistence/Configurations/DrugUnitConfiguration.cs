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
    public class DrugUnitConfiguration : IEntityTypeConfiguration<DrugUnitEntity>
    {
        public void Configure(EntityTypeBuilder<DrugUnitEntity> builder)
        {
            builder.ToTable("DrugUnit");
            builder.HasKey(x => x.Id);

            builder.HasOne<DrugEntity>()
                   .WithMany()
                   .HasForeignKey(x => x.DrugId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<DrugUnitEntity>()
                   .WithMany()
                   .HasForeignKey(x => x.ParentUnitId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
