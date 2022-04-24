using IisRest.Contracts.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IisRest.Data.Db.MsSql.Configuration
{
    internal class SoldAssetConfiguration : BaseEntityConfiguration<SoldAsset>
    {
        public override void Configure(EntityTypeBuilder<SoldAsset> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.AssetId)
                .IsRequired();

            builder.Property(p => p.ProfileId)
                .HasMaxLength(500);

            // builder.Property(p => p.PriceId)
            //    .IsRequired(true);

            builder.Property(p => p.SellDate)
                .IsRequired(true);

            builder.Property(p => p.Amount)
                .IsRequired(true);
        }
    }
}
