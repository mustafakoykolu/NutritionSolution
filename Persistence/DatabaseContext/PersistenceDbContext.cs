﻿using Domain.Common;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DatabaseContext
{
    public class PersistenceDbContext : DbContext
    {
        public PersistenceDbContext(DbContextOptions<PersistenceDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersistenceDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Food> Foods { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
                entry.Entity.CreatedBy = "User";
                entry.Entity.ModifiedBy = "User";
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
