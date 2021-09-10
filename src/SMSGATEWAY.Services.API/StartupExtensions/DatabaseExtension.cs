using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SMSGATEWAY.Infra.Data.Context;
using SMSGATEWAY.Infra.Identity.Data;

namespace SMSGATEWAY.Services.API.StartupExtensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddCustomizedDatabase(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment env)
        {
            // Replace with your server version and type.
            // Use 'MariaDbServerVersion' for MariaDB.
            // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
            // For common usages, see pull request #1233.
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));

            // Replace 'YourDbContext' with the name of your own DbContext derived class.
            ApplicationDatabaseConfiguration(services, configuration, env, serverVersion);
            
            AuthDatabaseConfiguration(services, configuration, env, serverVersion);
            EventDatabaseConfiguration(services, configuration, env, serverVersion);
            
            


            return services;
        }

        private static void EventDatabaseConfiguration(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env, MySqlServerVersion serverVersion)
        {
            services.AddDbContext<EventStoreSqlContext>(
                dbContextOptions =>
                {
                    dbContextOptions
                        .UseMySql(configuration.GetConnectionString("DefaultConnection"), serverVersion);

                    if (!env.IsProduction())
                    {
                        dbContextOptions.EnableSensitiveDataLogging() // <-- These two calls are optional but help
                            .EnableDetailedErrors(); // <-- with debugging (remove for production).
                    }
                });
        }

        private static void AuthDatabaseConfiguration(IServiceCollection services, IConfiguration configuration,
            IWebHostEnvironment env, MySqlServerVersion serverVersion)
        {
            services.AddDbContext<AuthDbContext>(
                dbContextOptions =>
                {
                    dbContextOptions
                        .UseMySql(configuration.GetConnectionString("DefaultConnection"), serverVersion);
                    
                    dbContextOptions.UseOpenIddict();

                    if (!env.IsProduction())
                    {
                        dbContextOptions.EnableSensitiveDataLogging() // <-- These two calls are optional but help
                            .EnableDetailedErrors(); // <-- with debugging (remove for production).
                    }
                });
        }

        private static void ApplicationDatabaseConfiguration(IServiceCollection services, IConfiguration configuration,
            IWebHostEnvironment env, MySqlServerVersion serverVersion)
        {
            services.AddDbContext<ApplicationDbContext>(
                dbContextOptions =>
                {
                    dbContextOptions
                        .UseMySql(configuration.GetConnectionString("DefaultConnection"), serverVersion);

                    if (!env.IsProduction())
                    {
                        dbContextOptions.EnableSensitiveDataLogging() // <-- These two calls are optional but help
                            .EnableDetailedErrors(); // <-- with debugging (remove for production).
                    }
                });
        }
    }
}