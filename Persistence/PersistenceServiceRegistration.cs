using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DatabaseContext;
using Persistence.Repositories;
using Persistence.UnitOfWorks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
       IConfiguration configuration)
        {
            services.AddDbContext<PersistenceDbContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("NutritionDbConnectionString"), npgsqlOptions => npgsqlOptions.CommandTimeout(720)).EnableSensitiveDataLogging().LogTo(Console.WriteLine);

        });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserTypeRepository>();
            services.AddScoped<IUnitOfWork, RepositoryTransactionUnitOfWork>();
            services.AddScoped<IMealRepository, MealRepository>();
            services.AddScoped<IFoodRepository, FoodRepository>();

            return services;
        }
    }
}
