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

            builder.HasOne(x => x.AssetPrice)
               .WithMany(x => x.SoldAssets)
               .HasForeignKey(x => x.AssetPriceId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.AssetPriceId)
                .IsRequired();

            builder.Property(p => p.ProfileId)
                .HasMaxLength(500);

            builder.Property(p => p.SellDate)
                .IsRequired(true);

            builder.Property(p => p.Amount)
                .IsRequired(true);
        }
    }
}
