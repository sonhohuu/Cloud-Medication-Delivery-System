using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure
{
    public class MedicationOrderServiceDbContext : DbContext
    {
        public MedicationOrderServiceDbContext(DbContextOptions<MedicationOrderServiceDbContext> options)
            : base(options)
        {
        }
        // Define DbSets for your entities here, e.g.:

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply Fluent API configurations from the current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Optional: Add additional configurations if required
            base.OnModelCreating(modelBuilder);
        }
    }
}
