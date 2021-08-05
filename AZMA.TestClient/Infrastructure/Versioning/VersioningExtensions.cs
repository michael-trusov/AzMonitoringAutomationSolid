using AZMA.Application.Infrastructure.Configuration;
using AZMA.TestClient.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using TestClient.Controllers;

namespace AZMA.TestClient.Infrastructure.Versioning
{
    public static class VersioningExtensions
    {
        public static void AddApiVersioning(this IServiceCollection serviceCollection, IAppSettings appSettings)
        {
            serviceCollection.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);

                options.ApiVersionReader = new HeaderApiVersionReader("x-api-version");

                // Note: define api version for the controllers
                var apiVersion1_0 = new ApiVersion(1, 0);

                //options.Conventions.Controller<ActivityLogAlertsController>()                                   
               //                    .HasApiVersion(apiVersion1_0);

                options.Conventions.Controller<CallbackController>()
                                   .HasApiVersion(apiVersion1_0);
                //options.Conventions.Controller<ControlPanelController>()
                //                   .HasApiVersion(apiVersion1_0);
                options.Conventions.Controller<ApimAlertsController>()
                                   .HasApiVersion(apiVersion1_0);
                //options.Conventions.Controller<QueryAlertsController>()
                //                   .HasApiVersion(apiVersion1_0);
                options.Conventions.Controller<ReportController>()
                                   .HasApiVersion(apiVersion1_0);

            });
        }
    }
}
