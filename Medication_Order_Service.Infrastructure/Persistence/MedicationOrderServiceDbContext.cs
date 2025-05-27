using Medication_Order_Service.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure.Persistence
{
    public class MedicationOrderServiceDbContext : DbContext
    {
        public MedicationOrderServiceDbContext()
        {
        }

        public MedicationOrderServiceDbContext(DbContextOptions<MedicationOrderServiceDbContext> options)
            : base(options)
        {
        }
        // Define DbSets for your entities here, e.g.:
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AuditLogEntity> AuditLogs { get; set; }
        public DbSet<NotificationEntity> Notifications { get; set; }
        public DbSet<PatientEntity> Patients { get; set; }
        public DbSet<MedicationOrderEntity> MedicationOrders { get; set; }
        public DbSet<MedicationOrderItemEntity> MedicationOrderItems { get; set; }
        public DbSet<DrugEntity> Drugs { get; set; }
        public DbSet<DrugCategoryEntity> DrugCategories { get; set; }
        public DbSet<DosageFormEntity> DosageForms { get; set; }
        public DbSet<DrugUnitEntity> DrugUnits { get; set; }
        public DbSet<LotEntity> Lots { get; set; }
        public DbSet<InventoryTransactionEntity> InventoryTransactions { get; set; }
        public DbSet<StorageLocationEntity> StorageLocations { get; set; }
        public DbSet<LotTransferEntity> LotTransfers { get; set; }
        public DbSet<SupplierEntity> Suppliers { get; set; }
        public DbSet<InboundEntity> Inbounds { get; set; }
        public DbSet<InboundDetailEntity> InboundDetails { get; set; }
        public DbSet<InboundTypeEntity> InboundTypes { get; set; }
        public DbSet<BillEntity> Bills { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply Fluent API configurations from the current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Optional: Add additional configurations if required
            base.OnModelCreating(modelBuilder);
        }
    }
}
