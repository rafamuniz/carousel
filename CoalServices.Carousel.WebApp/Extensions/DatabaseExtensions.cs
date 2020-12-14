using CoalServices.Carousel.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoalServices.Carousel.Extensions
{
    public static class DatabaseExtensions
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            // ===== ConnectionStrings ========
            var coalServicesConnection = configuration.GetConnectionString("CoalServicesConnection");
            // ===== ConnectionStrings ========

            if (String.IsNullOrEmpty(coalServicesConnection))
            {
                throw new ArgumentNullException("ConnectionString is required");
            }

            services.AddDbContext<CoalServicesContext>(options =>
                options.UseSqlServer(coalServicesConnection));

        }
    }
}
