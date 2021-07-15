using AZMA.Application.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZMA.TestClient.Infrastructure.Configuration
{
    public static class ConfigurationExtensions
    {
        public static IAppSettings AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = new AppSettings();

            configuration.Bind("TestApi", appSettings.TestApi);
            services.AddSingleton(appSettings.TestApi);

            configuration.Bind("Emulator", appSettings.Emulator);
            services.AddSingleton(appSettings.Emulator);

            configuration.Bind("Swagger", appSettings.Swagger);
            foreach (var configurationSection in configuration.GetSection("Swagger")
                                                              .GetSection("ApiVersions")
                                                              .GetChildren())
            {
                var apiVersionConfiguration = new ApiVersionConfiguration();
                configurationSection.Bind(apiVersionConfiguration);

                appSettings.Swagger.ApiVersions.Add(apiVersionConfiguration);
            }

            services.AddSingleton<IAppSettings>(appSettings);

            return appSettings;
        }
    }
}
