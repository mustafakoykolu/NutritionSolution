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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Food>()
                .HasIndex(f => f.Name)
                .IsUnique();

            modelBuilder.Entity<MealIngredient>()
                .HasKey(MealRecipe => new { MealRecipe.MealId, MealRecipe.FoodId }); // mealId and foodId are composite primary key

            // MealRecipe - Foreign Key Relationships
            modelBuilder.Entity<Meal>()
                .HasMany(m => m.MealIngredients) // Meal'in navigation property'si
                .WithOne(mi => mi.Meal) // MealIngredient'in navigation property'si
                .HasForeignKey(mi => mi.MealId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MealIngredient>()
                .HasOne(mi => mi.Food) // MealIngredient'in Food ile olan iliskisi
                .WithMany() // Food'un navigation property’si yoksa bu bos kalabilir.
                .HasForeignKey(mi => mi.FoodId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Food> Foods { get; set; } = null!;
        public DbSet<Meal> Meals { get; set; } = null!;
        public DbSet<MealIngredient> MealRecipes { get; set; } = null!;

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
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
