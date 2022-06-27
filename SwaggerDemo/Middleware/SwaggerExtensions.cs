using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerDocumentation.SwaggerDemo.Middleware;

/// <summary>
/// Sources: <br />
/// https://docs.swagger.io/spec.html <br />
/// https://github.com/domaindrivendev/Swashbuckle.AspNetCore
/// </summary>
public static class SwaggerExtensions
{
    /// <summary>
    /// Initialises and add Swagger to the IServiceCollection container.
    /// </summary>
    /// <param name="services">IServiceCollection container to add Swagger to.</param>
    /// <returns>IServiceCollection container instance.</returns>
    public static IServiceCollection AddSwaggerMiddleware(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.CustomOperationIds(
                controller =>
                    controller.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null
            );
            options.EnableAnnotations();
            options.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Swagger Documenation Demo API",
                    Description =
                        "An ASP.NET Core Web API for showing off meaningful Swagger documentation",
                    TermsOfService = new Uri("https://www.sidetrade.com/terms-of-use/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Sidetrade Contact",
                        Url = new Uri("https://www.sidetrade.com/contact-us/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Sidetrade License",
                        Url = new Uri("https://www.sidetrade.com/terms-of-use/")
                    }
                }
            );
        });
        return services;
    }

    /// <summary>
    /// Register the Swagger middleware.
    /// </summary>
    /// <param name="builder">The WebApplicationBuilder instance to extend.</param>
    /// <returns>An instance of WebApplicationBuilder.</returns>
    public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder builder)
    {
        builder.UseSwagger();
        builder.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
        return builder;
    }
}
