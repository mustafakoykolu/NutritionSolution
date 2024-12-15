﻿using Application.Contracts.Persistence;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly PersistenceDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(PersistenceDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        async Task<List<T>> IGenericRepository<T>.GetAllAsync()
        {
            var objectList = await _dbSet.ToListAsync();
            return objectList;
        }
    }
}
