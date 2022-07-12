using MarsPanel.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using Microsoft.Extensions.Configuration;
using System;
using MarsPanel.Configuration;
using MarsPanel.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace MarsPanel
{
    public static class HostingExtensions
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<RestClient, HttpClient>(context =>
                new HttpClient(new Uri(builder.Configuration.GetValue<string>("rootUrl")),
                builder.Configuration.GetValue<string>("ApiKey")));

            builder.Services.AddOptions().Configure<EndpointsSettings>(builder.Configuration.GetSection("endpoints"));
            builder.Services.AddTransient<IDataService, DataService>();
            builder.Services.AddControllers().AddNewtonsoftJson();

            builder.Services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            return builder;
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!app.Environment.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
            // To learn more about options for serving an Angular SPA from ASP.NET Core,
            // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (app.Environment.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            return app;
        }
    }
}
