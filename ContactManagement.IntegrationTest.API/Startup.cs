using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using ContactManagement.IoC;

namespace ContactManagement.IntegrationTest.API
{
    /// <summary>
    /// This class is responsible to configure the application middlewares and some configurations
    /// </summary>
    public class Startup
    {
        public Startup() { }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .ConfigureContactManagementServices();

            services
                .AddControllers()
                .AddNewtonsoftJson(opcoes => opcoes.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}