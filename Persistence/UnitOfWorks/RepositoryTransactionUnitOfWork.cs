using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UnitOfWorks
{
    public class RepositoryTransactionUnitOfWork(PersistenceDbContext context) : IUnitOfWork
    {
        private readonly PersistenceDbContext _context = context;
        private IDbContextTransaction? _transaction;

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("Transaction has not been started. Call BeginTransactionAsync first.");

            await _transaction.CommitAsync();

        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Transaction has not been started. Call BeginTransactionAsync first.");
            }
            
            await _transaction.RollbackAsync();
            
        }

        public void Dispose()
        {
            _transaction?.Dispose();
        }

    }
}
