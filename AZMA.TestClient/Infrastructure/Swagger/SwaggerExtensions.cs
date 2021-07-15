using AZMA.Application.Infrastructure.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Linq;

namespace AZMA.TestClient.Infrastructure.Swagger
{
    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services, ISwaggerConfiguration swaggerConfiguration)
        {
            if (swaggerConfiguration.Enabled)
            {
                services.AddSwaggerGen(options =>
                {
                    foreach (var apiVersion in swaggerConfiguration.ApiVersions)
                    {
                        options.SwaggerDoc(apiVersion.DocumentationId, new OpenApiInfo
                        {
                            Title = apiVersion.ApiTitle,
                            Version = apiVersion.Version.ToString(),
                            Description = apiVersion.ApplicationDescription
                        });
                    }

                    options.DocInclusionPredicate((documentationName, apiDescription) =>
                    {
                        var actionApiVersionModels = apiDescription.ActionDescriptor.GetApiVersionModel(ApiVersionMapping.Explicit | ApiVersionMapping.Implicit);
                        if (actionApiVersionModels == null)
                            return true;

                        if (actionApiVersionModels.DeclaredApiVersions.Any())
                        {
                            return actionApiVersionModels.DeclaredApiVersions
                                                         .Any(e => string.Format(swaggerConfiguration.DocumentIdFormat, e.MajorVersion, e.MinorVersion) == documentationName);
                        }

                        return actionApiVersionModels.ImplementedApiVersions
                                                     .Any(e => string.Format(swaggerConfiguration.DocumentIdFormat, e.MajorVersion, e.MinorVersion) == documentationName);
                    });
                });
            }
        }

        public static void UseSwagger(this IApplicationBuilder app, ISwaggerConfiguration swaggerConfiguration)
        {
            if (swaggerConfiguration.Enabled)
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    foreach (var apiVersion in swaggerConfiguration.ApiVersions)
                    {
                        options.SwaggerEndpoint($"/swagger/{apiVersion.DocumentationId}/swagger.json", apiVersion.ApiTitle);
                    }
                });
            }
        }
    }
}
