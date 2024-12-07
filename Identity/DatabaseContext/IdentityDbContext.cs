using Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DatabaseContext
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
            //    .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            //{
            //    entry.Entity.DateModified = DateTime.Now;
            //    if (entry.State == EntityState.Added)
            //    {
            //        entry.Entity.DateCreated = DateTime.Now;
            //    }
            //}

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
