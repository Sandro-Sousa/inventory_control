using Entities.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(p => p.IdProduct);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.PurchasePrice).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(p => p.SaleValue).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(p => p.StockBalance).IsRequired();
        }
    }
}
