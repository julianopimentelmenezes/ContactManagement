using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ContactManagement.IoC;
using Newtonsoft.Json;
using ContactManagement.Domain.Data;
using Microsoft.Extensions.Configuration;

namespace ContactManagement.API
{
    /// <summary>
    /// This class is responsible to configure the application middlewares and some configurations
    /// </summary>
    public class Startup
    {
        readonly IConfiguration _configuration;
        public Startup(IWebHostEnvironment env)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.
                ConfigureContactManagementServices();

            services
                .AddControllers()
                .AddNewtonsoftJson(opcoes => opcoes.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);
        }

        /// <summary>
        /// In this function, the middleware swagger is configured
        /// Is called the function to create fake data
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ContactManagementContext contactManagementContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                contactManagementContext.Database.EnsureDeleted();
                contactManagementContext.Database.EnsureCreated();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact Management");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
