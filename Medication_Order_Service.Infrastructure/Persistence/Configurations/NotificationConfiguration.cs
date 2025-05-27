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
    public class NotificationConfiguration : IEntityTypeConfiguration<NotificationEntity>
    {
        public void Configure(EntityTypeBuilder<NotificationEntity> builder)
        {
            builder.ToTable("Notification");
            builder.HasKey(x => x.Id);

            builder.HasOne<AccountEntity>()
                   .WithMany(a => a.Notifications)
                   .HasForeignKey(x => x.AssignedToAccountId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
