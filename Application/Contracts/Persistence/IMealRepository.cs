﻿using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IMealRepository : IGenericRepository<Meal>
    {
        Task<List<Meal>> GetMealsWithIngredientsAsync();
        Task<int> AddAsync(Meal meal);
        Task<Meal> GetMealsWithIngredientsByIdAsync(int id);
        Task<List<Meal>> GetMealsPagedAsync(int pageNumber,int pageSize);
    }
}
