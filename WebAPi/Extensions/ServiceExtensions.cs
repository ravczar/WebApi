using Contracts;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities;
using Repository;

namespace WebAPi.Extensions
{
    /// <summary>
    /// This is called by Startup class in WebApi project.
    /// Consists of services that are included in the API (CORS, MySQL, ISS, SWAGGER).
    /// </summary>
    /// <see cref="Startup.ConfigureServices(IServiceCollection)"/>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Connection policy where you might setup which applications/websites can access the API and choose which actions (GET/POST/others) are applicable.
        /// </summary>
        /// <param name="services">API service collection descriptors.</param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        /// <summary>
        /// Configuration of ISS to launch the API with specified settings/options.
        /// </summary>
        /// <param name="services">API service collection descriptors.</param>
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }

        /// <summary>
        /// Add singleton LoggerManager - One instance to be used in many Controllers through Dependency Injection
        /// </summary>
        /// <param name="services">API service collection descriptors</param>
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        /// <summary>
        /// Add MySql context configuration.
        /// Used for establishing a connection with the database.
        /// </summary>
        /// <param name="services">API service collection descriptors.</param>
        /// <param name="config">appsetting.json access.</param>
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            /// <string> MySQL connection string from appseting.json
            var connectionString = config["mysqlconnection:connectionString"];
            services.AddDbContext<RepositoryContext>
                (o => o.UseMySql(connectionString, MySqlServerVersion.LatestSupportedServerVersion));
        }

        /// <summary>
        /// Add Repository wrapper to inject one instance into controller.
        /// </summary>
        /// <param name="services">API service collection descriptors.</param>
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

    }
}
