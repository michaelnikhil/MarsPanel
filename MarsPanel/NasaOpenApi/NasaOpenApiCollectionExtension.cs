using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsPanel.NasaOpenApi
{
    public static class NasaOpenApiCollectionExtension
    {
        public static void AddNasaOpenApi(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient<INasaOpenApiClient, NasaOpenApiClient>(client =>
            {
                client.BaseAddress = new Uri(config.GetValue<string>("OpenApiRootUrl"));
            });
        }
    }
}
