using IisRest.Contracts.Entities;
using IisRest.Contracts.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IisRest.Data.Db.MsSql.Configuration
{
    internal class AssetConfiguration : BaseEntityConfiguration<Asset>
    {
        public override void Configure(EntityTypeBuilder<Asset> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired(true);

            builder.Property(x => x.Symbol)
                .HasMaxLength(25)
                .IsRequired(true);

            builder.Property(x => x.AssetType)
                .HasConversion(
                    x => (int)x,
                    x => x.GetAssetTypeFromInt())
                .IsRequired(true);
        }
    }
}
