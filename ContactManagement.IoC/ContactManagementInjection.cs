using AutoMapper;
using ContactManagement.Business;
using ContactManagement.Business.Interfaces;
using ContactManagement.Business.Mappings;
using ContactManagement.Domain.Data;
using ContactManagement.Domain.Interfaces.Repositories;
using ContactManagement.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using System;

namespace ContactManagement.IoC
{
    /// <summary>
    /// This class is responsible to configure the dependency injection of the API
    /// </summary>
    public static class ContactManagementInjection
    {
        public static IServiceCollection ConfigureContactManagementServices(this IServiceCollection services)
        {
            services
                .AddBusiness()
                .AddDataContext()
                .AddRepository()
                .ConfigureAutoMapper()
                .ConfigureSwaggerApi();

            using (var sp = services.BuildServiceProvider())
            {
                services.TryAddSingleton<IConfiguration>(sp.GetService<IConfiguration>());
                services.TryAddSingleton<IWebHostEnvironment>(sp.GetService<IWebHostEnvironment>());
            }

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }

        /// <summary>
        /// In this method is configured the swagger. 
        /// </summary>
        public static IServiceCollection ConfigureSwaggerApi(this IServiceCollection services)
        {
            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = $"Contact Management",
                        Description = $"API for contact management"
                    });
                });

            return services;
        }

        /// <summary>
        /// In this method is configured the automapper. Here is called the mapping register
        /// </summary>
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            AutoMapperConfig.RegisterMappings();

            return services;
        }

        #region [Private methods]

        /// <summary>
        /// In this method is configured the data context. 
        /// Was used the new functionality In Memory Database. With this funcionality, is not necessary have any database.
        /// </summary>
        private static IServiceCollection AddDataContext(this IServiceCollection services)
        {
            services.AddDbContext<ContactManagementContext>(options => options.UseInMemoryDatabase(databaseName: "ContactManagement"));

            return services;
        }

        /// <summary>
        /// In this method is configured the business dependency. 
        /// </summary>
        private static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services
                .TryAddScoped<IContactManagementBusiness, ContactManagementBusiness>();

            return services;
        }

        /// <summary>
        /// In this method is configured the repository  dependency. 
        /// </summary>
        private static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services
                .TryAddScoped<IContactRepository, ContactRepository>();

            return services;
        }

        #endregion [Private methods]

    }
}
