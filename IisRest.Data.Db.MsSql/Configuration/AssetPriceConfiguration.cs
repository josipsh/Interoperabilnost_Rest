using IisRest.Contracts.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IisRest.Data.Db.MsSql.Configuration
{
    internal class AssetPriceConfiguration : BaseEntityConfiguration<AssetPrice>
    {
        public override void Configure(EntityTypeBuilder<AssetPrice> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PriceId)
                .IsRequired(true);

            builder.Property(x => x.AssetId)
                .IsRequired(true);

        }
    }
}
