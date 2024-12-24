using Application.Contracts.Persistence;
using Domain;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class FoodRepository : GenericRepository<Food>, IFoodRepository
    {
        public FoodRepository(PersistenceDbContext context) : base(context)
        {

        }
        public async Task<List<Food>> GetAllAsync()
        {
            var objectList = await _dbSet
                .Include(f => f.FoodNutrients)
                    .ThenInclude(f => f.Nutrient)
                .Include(f => f.FoodNutrients)
                .ThenInclude(fn => fn.Derivation)
                .Include(f => f.FoodPortions)
                    .ThenInclude(f => f.MeasureUnit)
                .Include(f => f.InputFoods)
                .Include(f => f.NutrientConversionFactors)
                .Include(f => f.FoodCategory)
                .ToListAsync();
            return objectList;
        }
        public async Task<List<Food>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var objectList = await _dbSet
                .Include(f=> f.FoodNutrients)
                    .ThenInclude(f=> f.Nutrient)
                .Include(f => f.FoodNutrients)
                .ThenInclude(fn => fn.Derivation)
                .Include(f => f.FoodPortions)
                    .ThenInclude(f=> f.MeasureUnit)
                .Include(f=> f.InputFoods)
                .Include(f=> f.NutrientConversionFactors)
                .Include(f=> f.FoodCategory)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return objectList;
        }
        public async Task<List<Food>> SearchByName(string foodName, int pageNumber, int pageSize)
        {
            var objectList = await _dbSet
                .Include(f => f.FoodNutrients)
                    .ThenInclude(f => f.Nutrient)
                .Include(f => f.FoodNutrients)
                .ThenInclude(fn => fn.Derivation)
                .Include(f => f.FoodPortions)
                    .ThenInclude(f => f.MeasureUnit)
                .Include(f => f.InputFoods)
                .Include(f => f.NutrientConversionFactors)
                .Include(f => f.FoodCategory).Where(f => f.DescriptionTr.ToLower().Contains(foodName.ToLower())).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return objectList;
        }
        public async Task<int> SearchByNameCount(string foodName, int pageNumber, int pageSize)
        {
            var count = await _dbSet.Where(f => f.DescriptionTr.ToLower().Contains(foodName.ToLower())).CountAsync();
            return count;
        }

        public async Task<int>  GetCountAsync()
        {
            var count = await _dbSet
               .Include(f => f.FoodNutrients)
                   .ThenInclude(f => f.Nutrient)
               .Include(f => f.FoodNutrients)
               .ThenInclude(fn => fn.Derivation)
               .Include(f => f.FoodPortions)
                   .ThenInclude(f => f.MeasureUnit)
               .Include(f => f.InputFoods)
               .Include(f => f.NutrientConversionFactors)
               .Include(f => f.FoodCategory).CountAsync();
            return count;
        }

    }
}
