using Persistence;
using Infrastructure;
using Application;
using Identity;
using Api.Filters;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews(
    options => { 
        options.Filters.Add<CustomExceptionFilter>();
    }
);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder =>
    {
        // CORS izin verilen domain'ler
        builder.WithOrigins(
                "https://fitlezzet.com",
                "http://fitlezzet.com",
                "https://www.fitlezzet.com",
                "http://www.fitlezzet.com"
            )
            .AllowAnyHeader() 
            .AllowAnyMethod(); 
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("all");
app.UseAuthorization();

app.MapControllers();

//resim
//app.UseStaticFiles();  
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(@"C:\images"), 
//    RequestPath = "/images"  
//});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    //await SeedData.Initialize(services, userManager);
}

app.Run();
