using IisRest.Contracts.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IisRest.Data.Db.MsSql.Configuration
{
    internal class PriceConfiguration : BaseEntityConfiguration<Price>
    {
        public override void Configure(EntityTypeBuilder<Price> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.AssetPrice)
               .WithOne(x => x.Price)
               .HasForeignKey<AssetPrice>(x => x.PriceId);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CurrencyId)
                .IsRequired(true);

            builder.Property(x => x.PriceRate)
                .IsRequired(true);

            builder.Property(x => x.PriceDate)
                .IsRequired(true);
        }
    }
}
