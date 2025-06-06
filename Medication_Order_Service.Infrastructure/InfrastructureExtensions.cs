using Medication_Order_Service.Infrastructure.Persistence;
using Medication_Order_Service.Infrastructure.Persistence.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Medication_Order_Service.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            // Register DbContext with a connection string
            services.AddDbContext<MedicationOrderServiceDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("local")));

            return services;
        }
    }
}
