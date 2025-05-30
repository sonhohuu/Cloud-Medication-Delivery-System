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
    public class MedicationOrderConfiguration : IEntityTypeConfiguration<MedicationOrderEntity>
    {
        public void Configure(EntityTypeBuilder<MedicationOrderEntity> builder)
        {
            builder.ToTable("MedicationOrder");
            builder.HasKey(x => x.Id);
            builder.ToTable("MedicationOrder");
            builder.HasKey(x => x.Id);

            builder.HasOne(m => m.Doctor)
                .WithMany(a => a.MedicationOrdersAsDoctor)
                .HasForeignKey(m => m.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.CreatedByAccount)
                .WithMany(a => a.MedicationOrdersCreated)
                .HasForeignKey(m => m.CreatedByAccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
