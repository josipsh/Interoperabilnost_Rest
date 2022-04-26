using System.Reflection;
using IisRest.Contracts.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IisRest.Data.Db.MsSql.Configuration
{
    public class ApplicationDbContext : IdentityDbContext<UserProfile, IdentityRole<int>, int>
    {
        public DbSet<UserProfile> Profiles { get; set; } = default!;
        public DbSet<Price> Prices { get; set; } = default!;
        public DbSet<BoughtAsset> BoughtAssets { get; set; } = default!;
        public DbSet<SoldAsset> SoldAssets { get; set; } = default!;
        public DbSet<Currency> Currencies { get; set; } = default!;
        public DbSet<Asset> Assets { get; set; } = default!;
        public DbSet<AssetPrice> AssetPrices { get; set; } = default!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // synchronous and asynchronous must be overridden in order to save date created and modified
        public override int SaveChanges()
        {
            SavingChanges += ApplicationDbContext_SavingChanges;
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.SavingChanges += ApplicationDbContext_SavingChanges;
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void ApplicationDbContext_SavingChanges(object? sender, SavingChangesEventArgs e)
        {
            if (!ChangeTracker.HasChanges())
            {
                return;
            }

            var addedEntities = ChangeTracker
                .Entries()
                .Where(x => x.State == EntityState.Added)
                .Select(x => x.Entity)
                .ToList();

            addedEntities.ForEach(x =>
            {
                if (x is IBaseEntity)
                {
                    ((IBaseEntity)x).DateCreated = DateTime.Now;
                    ((IBaseEntity)x).DateModified = DateTime.Now;
                }
            });

            var modifiedEntities = ChangeTracker
                .Entries()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity)
                .ToList();

            modifiedEntities.ForEach(x =>
            {
                if (x is IBaseEntity)
                {
                    ((IBaseEntity)x).DateModified = DateTime.Now;
                }
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
