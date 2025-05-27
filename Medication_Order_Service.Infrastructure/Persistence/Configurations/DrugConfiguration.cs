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
    public class DrugConfiguration : IEntityTypeConfiguration<DrugEntity>
    {
        public void Configure(EntityTypeBuilder<DrugEntity> builder)
        {
            builder.ToTable("Drug");
            builder.HasKey(x => x.Id);

            builder.HasOne<DosageFormEntity>()
                   .WithMany()
                   .HasForeignKey(x => x.DosageFormId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<DrugCategoryEntity>()
                   .WithMany()
                   .HasForeignKey(x => x.DrugCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
