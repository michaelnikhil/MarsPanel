using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using MarsPanel;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

var app = builder.Build();

app.ConfigurePipeline();

app.Run();