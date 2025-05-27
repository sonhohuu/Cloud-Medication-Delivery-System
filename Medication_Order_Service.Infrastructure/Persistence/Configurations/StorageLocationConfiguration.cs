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
    public class StorageLocationConfiguration : IEntityTypeConfiguration<StorageLocationEntity>
    {
        public void Configure(EntityTypeBuilder<StorageLocationEntity> builder)
        {
            builder.ToTable("StorageLocation");
            builder.HasKey(x => x.Id);
        }
    }
}
