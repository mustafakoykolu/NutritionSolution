﻿using Application.Contracts.Persistence;
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
            var objectList = await _dbSet.ToListAsync();

            return objectList;
        }
        public async Task<List<Food>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var objectList = await _dbSet
                .Include(f=> f.Vitamin)
                .Include(f => f.Mineral)
                .Include(f=> f.Carbohydrate)
                    .ThenInclude(f=> f.Sugar)
                .Include(f=>f.Fat)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return objectList;
        }
        public async Task<List<Food>> SearchByName(string foodName, int pageNumber, int pageSize)
        {
            var objectList = await _dbSet.Include(f => f.Vitamin)
                .Include(f => f.Mineral)
                .Include(f => f.Carbohydrate)
                    .ThenInclude(f => f.Sugar)
                .Include(f => f.Fat).Where(f => f.NameTr.ToLower().Contains(foodName.ToLower())).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return objectList;
        }
        public async Task<int> SearchByNameCount(string foodName, int pageNumber, int pageSize)
        {
            var count = await _dbSet.Where(f => f.NameTr.ToLower().Contains(foodName.ToLower())).CountAsync();
            return count;
        }

        public async Task<int>  GetCountAsync()
        {
            var count = await _dbSet.CountAsync();
            return count;
        }
        public new async Task<Food> GetByIdAsync(int id)
        {
            var food = await _dbSet.Include(f => f.Vitamin)
                .Include(f => f.Mineral)
                .Include(f => f.Carbohydrate)
                    .ThenInclude(f => f.Sugar)
                .Include(f => f.Fat).Where(f=> f.Id == id).FirstAsync();
            return food;
        }

    }
}
