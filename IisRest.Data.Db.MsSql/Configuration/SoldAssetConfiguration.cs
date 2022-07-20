using IisRest.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IisRest.Data.Db.MsSql.Configuration
{
    internal class SoldAssetConfiguration : BaseEntityConfiguration<SoldAsset>
    {
        public override void Configure(EntityTypeBuilder<SoldAsset> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => p.Id);

            builder.HasOne(x => x.Price)
               .WithMany()
               .HasForeignKey(x => x.PriceId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Asset)
               .WithMany()
               .HasForeignKey(x => x.AssetId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.PriceId)
                .IsRequired();

            builder.Property(p => p.AssetId)
                .IsRequired(true);

            builder.Property(p => p.ProfileId)
                .HasMaxLength(500);

            builder.Property(p => p.SellDate)
                .IsRequired(true);

            builder.Property(p => p.Amount)
                .IsRequired(true);
        }
    }
}
