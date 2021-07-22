using AZMA.TestClient.Infrastructure.Configuration;
using AZMA.TestClient.Infrastructure.DependencyInjection;
using AZMA.TestClient.Infrastructure.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AZMA.TestClient.Infrastructure.Versioning;
using AZMA.Application.Infrastructure.Configuration;
using AZMA.Application.Infrastructure.DependencyInjection;

namespace TestClient
{
    public class Startup
    {
        private IAppSettings AppSettings { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry(
                Configuration["APPINSIGHTS_CONNECTIONSTRING"]);

            AppSettings = services.AddConfiguration(Configuration);

            services.AddTestClientServices(AppSettings);
            services.AddApplicationServices();

            services.AddApiVersioning(AppSettings);
            services.AddSwagger(AppSettings.Swagger);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger(AppSettings.Swagger);
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
