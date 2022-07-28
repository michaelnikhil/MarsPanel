using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsPanel.MarsNasa
{
    public static class MarsNasaApiCollectionExtension
    {
        public static void AddMarsNasaApi(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient<IMarsNasaClient, MarsNasaClient>(client =>
            {
                client.BaseAddress = new Uri(config.GetValue<string>("Curiosity:RootUrl"));
            });
        }
    }
}
