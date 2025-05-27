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
    public class DosageFormConfiguration : IEntityTypeConfiguration<DosageFormEntity>
    {
        public void Configure(EntityTypeBuilder<DosageFormEntity> builder)
        {
            builder.ToTable("DosageForm");
            builder.HasKey(x => x.Id);
        }
    }
}
