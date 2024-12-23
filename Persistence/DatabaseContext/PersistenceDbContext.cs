using Domain.Common;
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

            //// Relationships
            //modelBuilder.Entity<Food>().HasMany(f => f.FoodPortions)
            //      .WithOne(fp => fp.food)
            //      .HasForeignKey(fp => fp.FoodId)
            //      .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity(Food).HasMany(f => f.FoodNutrients)
            //      .WithOne(fn => fn.Food)
            //      .HasForeignKey(fn => fn.FoodId)
            //      .OnDelete(DeleteBehavior.Cascade);

            //entity.HasMany(f => f.InputFoods)
            //      .WithOne(ifd => ifd.Food)
            //      .HasForeignKey(ifd => ifd.FoodId)
            //      .OnDelete(DeleteBehavior.Cascade);

            //entity.HasOne(f => f.FoodCategory)
            //      .WithMany(fc => fc.Foods)
            //      .HasForeignKey(f => f.FoodCategoryId)
            //      .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodNutrient> FoodNutrients { get; set; }
        public DbSet<FoodNutrientDerivation> FoodNutrientDerivations { get; set; }
        public DbSet<FoodNutrientSource> FoodNutrientSources { get; set; }
        public DbSet<NutrientConversionFactor> NutrientConversionFactors { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodPortion> FoodPortions { get; set; }
        public DbSet<MeasureUnit> MeasureUnits { get; set; }
        public DbSet<InputFood> InputFoods { get; set; }
        public DbSet<Nutrient> Nutrients { get; set; }

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
            //    entry.Entity.CreatedBy = "User";
            //    entry.Entity.ModifiedBy = "User";
            //}
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
