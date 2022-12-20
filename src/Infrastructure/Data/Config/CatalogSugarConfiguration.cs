using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.eShopWeb.ApplicationCore.Entities;

namespace Microsoft.eShopWeb.Infrastructure.Data.Config
{
    public class CatalogSugarConfiguration : IEntityTypeConfiguration<CatalogSugar>
    {
        public void Configure(EntityTypeBuilder<CatalogSugar> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .UseHiLo("catalog_sugar_hilo")
               .IsRequired();

            builder.Property(cb => cb.Sugar)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}