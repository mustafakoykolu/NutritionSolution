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

            // Food sınıfı için benzersiz indexler
            modelBuilder.Entity<Food>()
                .HasIndex(f => f.Name)
                .IsUnique();

            modelBuilder.Entity<Food>()
                .HasIndex(f => f.NameTr)
                .IsUnique();


            // Food sınıfı için, vitamin ve mineral bağlantıları
            modelBuilder.Entity<Food>()
                .HasOne(f => f.Vitamin)  // Food ile Vitamin ilişkisi
                .WithOne()  // Her Food'un bir Vitamin'i vardır, ancak ters ilişki kurulmamıştır
                .HasForeignKey<Vitamin>(f => f.FoodId)
                .OnDelete(DeleteBehavior.Cascade);  // Vitamin silindiğinde Food etkilenmesin

            modelBuilder.Entity<Food>()
                .HasOne(f => f.Mineral)  // Food ile Mineral ilişkisi
                .WithOne()  // Her Food'un bir Mineral'i vardır, ancak ters ilişki kurulmamıştır
                .HasForeignKey<Mineral>(f => f.FoodId)
                .OnDelete(DeleteBehavior.Cascade);  // Mineral silindiğinde Food etkilenmesin

            modelBuilder.Entity<Food>()
                .HasOne(f => f.Carbohydrate)  // Food ile Carbohydrate ilişkisi
                .WithOne()  // Her Food'un bir Carbohydrate'i vardır
                .HasForeignKey<Carbohydrate>(f => f.FoodId)
                .OnDelete(DeleteBehavior.Cascade);  // Carbohydrate silindiğinde Food etkilenmesin

            modelBuilder.Entity<Food>()
                .HasOne(f => f.Fat)  // Food ile Lipid ilişkisi
                .WithOne()  // Her Food'un bir Lipid'i vardır
                .HasForeignKey<Lipid>(f => f.FoodId)
                .OnDelete(DeleteBehavior.Cascade);  // Lipid silindiğinde Food etkilenmesin

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Carbohydrate> Carbohydrates { get; set; }
        public DbSet<Lipid> Lipids { get; set; }
        public DbSet<Mineral> Minerals { get; set; }
        public DbSet<Sugar> Sugars { get; set; }
        public DbSet<Vitamin> Vitamins { get; set; }
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
