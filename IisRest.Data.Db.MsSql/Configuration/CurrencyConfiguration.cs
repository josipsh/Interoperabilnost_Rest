using IisRest.Contracts.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IisRest.Data.Db.MsSql.Configuration
{
    internal class CurrencyConfiguration : BaseEntityConfiguration<Currency>
    {
        public override void Configure(EntityTypeBuilder<Currency> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Prices)
                .WithOne(x => x.Currency)
                .HasForeignKey(x => x.CurrencyId);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(x => x.Symbol)
                .HasMaxLength(25)
                .IsRequired(true);
        }
    }
}
