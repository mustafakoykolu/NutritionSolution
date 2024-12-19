using Persistence;
using Infrastructure;
using Application;
using Identity;
using Api.Filters;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Serilog.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

// Global Logger Ayarı
Log.Logger = new LoggerConfiguration()
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
    {
        AutoRegisterTemplate = true,
        IndexFormat = "logs-{0:yyyy.MM.dd}"
    })
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();

//default serilog middleware.
//builder.Host.UseSerilog();

builder.Services.AddControllers(
    options =>
    {
        options.Filters.Add<CustomExceptionFilter>();
    });

builder.Services.AddOpenApi();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();


app.UseMiddleware<Api.Middleware.RequestResponseLoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("all");
app.UseAuthorization();
app.MapControllers();

app.Run();
