using IisRest.Contracts.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IisRest.Data.Db.MsSql.Configuration
{
    internal class BoughtAssetConfiguration : BaseEntityConfiguration<BoughtAsset>
    {
        public override void Configure(EntityTypeBuilder<BoughtAsset> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.AssetId)
                .IsRequired(true);

            builder.Property(p => p.ProfileId)
                .HasMaxLength(500);

            builder.Property(p => p.PriceId)
                .IsRequired(true);

            builder.Property(p => p.BuyDate)
                .IsRequired(true);

            builder.Property(p => p.Amount)
                .IsRequired(true);
        }
    }
}
