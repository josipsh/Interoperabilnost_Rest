using IisRest.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IisRest.Data.Db.MsSql.Configuration
{
    internal class ProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(a => a.BoughtAssets)
               .WithOne(p => p.Profile)
               .HasForeignKey(p => p.ProfileId);

            builder.HasMany(a => a.SoldAssets)
               .WithOne(p => p.Profile)
               .HasForeignKey(p => p.ProfileId);

            builder.Property(p => p.FirstName)
                .HasMaxLength(500)
                .IsRequired(true);

            builder.Property(p => p.MiddleName)
                .HasMaxLength(500);

            builder.Property(p => p.LastName)
                .HasMaxLength(500)
                .IsRequired(true);

            builder.Property(p => p.DateCreated)
                .IsRequired(true);

            builder.Property(p => p.DateModified)
                .IsRequired(true);
        }
    }
}
