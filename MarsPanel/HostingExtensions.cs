using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MarsPanel.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using MarsPanel.NasaOpenApi;
using MarsPanel.MarsNasa;
using MarsPanel.NasaOpenApi.Models;

namespace MarsPanel
{
    public static class HostingExtensions
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<ApodSettings>(builder.Configuration.GetSection("NasaApiEndpoints"));
            builder.Services.Configure<OpenApiEndpointSettings>(builder.Configuration.GetSection("NasaApiEndpoints"));
            builder.Services.Configure<GenericEndpointSettings>(builder.Configuration.GetSection("Curiosity"));
            builder.Services.AddNasaOpenApi(builder.Configuration);
            builder.Services.AddMarsNasaApi(builder.Configuration);
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
