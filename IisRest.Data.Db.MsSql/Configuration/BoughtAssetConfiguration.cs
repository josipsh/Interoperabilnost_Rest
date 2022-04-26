using IisRest.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IisRest.Data.Db.MsSql.Configuration
{
    internal class BoughtAssetConfiguration : BaseEntityConfiguration<BoughtAsset>
    {
        public override void Configure(EntityTypeBuilder<BoughtAsset> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => p.Id);

            builder.HasOne(x => x.AssetPrice)
               .WithMany(x => x.BoughtAssets)
               .HasForeignKey(x => x.AssetPriceId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.AssetPriceId)
                .IsRequired(true);

            builder.Property(p => p.ProfileId)
                .HasMaxLength(500);

            builder.Property(p => p.BuyDate)
                .IsRequired(true);

            builder.Property(p => p.Amount)
                .IsRequired(true);
        }
    }
}
