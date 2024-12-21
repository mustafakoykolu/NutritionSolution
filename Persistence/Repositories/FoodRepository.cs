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

        public async Task<List<Food>> SearchByName(string foodName, int pageNumber, int pageSize)
        {
            var objectList = await _dbSet.Where(x=> x.Name.Contains(foodName)).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return objectList;
        }
        public async Task<int> SearchByNameCount(string foodName, int pageNumber, int pageSize)
        {
            var count = await _dbSet.Where(x => x.Name.Contains(foodName)).CountAsync();
            return count;
        }

    }
}
