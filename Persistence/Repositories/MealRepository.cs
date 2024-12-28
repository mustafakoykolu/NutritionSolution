using Application.Contracts.Persistence;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories
{
    public class MealRepository : GenericRepository<Meal>, IMealRepository
    {
        public MealRepository(PersistenceDbContext context) : base(context) { }

        public async Task<List<Meal>> GetMealsWithIngredientsAsync()
        {
            var mealList= await _context.Meals
                .Include(m => m.MealFoods) // Meal -> MealFoods ilişkisi
                    .ThenInclude(mf => mf.Food) // MealFoods -> Food ilişkisi
                        .ThenInclude(f => f.Vitamin) // Food -> Vitamin
                .Include(m => m.MealFoods)
                    .ThenInclude(mf => mf.Food)
                        .ThenInclude(f => f.Mineral) // Food -> Mineral
                .Include(m => m.MealFoods)
                    .ThenInclude(mf => mf.Food)
                        .ThenInclude(f => f.Carbohydrate) // Food -> Carbohydrate
                            .ThenInclude(c => c.Sugar) // Carbohydrate -> Sugar
                .Include(m => m.MealFoods)
                    .ThenInclude(mf => mf.Food)
                        .ThenInclude(f => f.Fat) // Food -> Fat
                .ToListAsync();
            return mealList;
        }

        public async Task<int> AddAsync(Meal meal)
        {
            await _context.Meals.AddAsync(meal);
            await _context.SaveChangesAsync();
            return meal.Id;
        public async Task<List<Meal>> GetMealsPagedAsync(int pageNumber, int pageSize)
        {
            var mealList = await _context.Meals
                .Include(m => m.MealFoods) // Meal -> MealFoods ilişkisi
                    .ThenInclude(mf => mf.Food) // MealFoods -> Food ilişkisi
                        .ThenInclude(f => f.Vitamin) // Food -> Vitamin
                .Include(m => m.MealFoods)
                    .ThenInclude(mf => mf.Food)
                        .ThenInclude(f => f.Mineral) // Food -> Mineral
                .Include(m => m.MealFoods)
                    .ThenInclude(mf => mf.Food)
                        .ThenInclude(f => f.Carbohydrate) // Food -> Carbohydrate
                            .ThenInclude(c => c.Sugar) // Carbohydrate -> Sugar
                .Include(m => m.MealFoods)
                    .ThenInclude(mf => mf.Food)
                        .ThenInclude(f => f.Fat) // Food -> Fat
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
