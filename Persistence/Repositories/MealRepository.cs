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
            var meal= await _dbSet
                .Include(m => m.MealIngredients)
                .ToListAsync();
            return meal;
        }
    }
}
