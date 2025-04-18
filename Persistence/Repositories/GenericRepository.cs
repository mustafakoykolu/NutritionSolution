﻿using Application.Contracts.Persistence;
using Application.Exceptions;
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
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(PersistenceDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<int> CreateAsync(T entity)
        {
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            catch (DbUpdateException ex)//todo: exception kotnrol edilecek.
            {
                var innerException = ex.InnerException?.Message;
                throw new Exception($"An error occurred while saving the entity changes: {innerException}", ex);
            }
        }

        public async Task<int> DeleteAsync(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            catch (DbUpdateException ex)//todo: exception kotnrol edilecek.
            {
                var innerException = ex.InnerException?.Message;
                throw new Exception($"An error occurred while saving the entity changes: {innerException}", ex);
            }

        }

        public async Task<T> GetByIdAsync(int id)
        {
            var data = await _dbSet.FindAsync(id);
            return data ?? throw new BadRequestException($"{id} could not found in db");
        }

        public IQueryable<T> QueryAsync()
        {
             return _dbSet.AsQueryable();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            catch (DbUpdateException ex)//todo: exception kotnrol edilecek.
            {
                var innerException = ex.InnerException?.Message;
                throw new Exception($"An error occurred while saving the entity changes: {innerException}", ex);
            }
        }

        async Task<List<T>> IGenericRepository<T>.GetAllAsync()
        {
            var objectList = await _dbSet.ToListAsync();
            return objectList;
        }
        async Task<List<T>> IGenericRepository<T>.GetPagedAsync(int pageNumber, int pageSize)
        {
            var objectList = await _dbSet.Skip((pageNumber-1)*pageSize).Take(pageSize).ToListAsync();
            return objectList;
        }
        async Task<int> IGenericRepository<T>.GetCountAsync()
        {
            var count = await _dbSet.CountAsync();
            return count;
        }
    }
}
