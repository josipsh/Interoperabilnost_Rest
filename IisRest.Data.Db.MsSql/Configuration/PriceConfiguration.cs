using IisRest.Contracts.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IisRest.Data.Db.MsSql.Configuration
{
    internal class PriceConfiguration : BaseEntityConfiguration<Price>
    {
        public override void Configure(EntityTypeBuilder<Price> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AssetId)
               .IsRequired(true);

            builder.Property(x => x.CurrencyId)
                .IsRequired(true);

            builder.Property(x => x.PriceRate)
                .IsRequired(true);

            builder.Property(x => x.PriceDate)
                .IsRequired(true);
        }
    }
}
