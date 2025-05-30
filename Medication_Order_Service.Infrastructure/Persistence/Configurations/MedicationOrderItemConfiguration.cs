﻿using Medication_Order_Service.Infrastructure.Persistence.Entities;
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
    public class MedicationOrderItemConfiguration : IEntityTypeConfiguration<MedicationOrderItemEntity>
    {
        public void Configure(EntityTypeBuilder<MedicationOrderItemEntity> builder)
        {
            builder.ToTable("MedicationOrderItem");
            builder.HasKey(x => x.Id);

            
        }
    }
}
