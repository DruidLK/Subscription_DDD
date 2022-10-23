using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subscriptions.Domain.Products;

namespace Subscriptions.Infrastructure.config
{
    public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));
            builder.HasKey(product => product.Id);
            builder.Property(product => product.Id).HasColumnName("ProductId").ValueGeneratedOnAdd().IsRequired();
            builder.Property(product => product.Name).HasMaxLength(100).IsRequired();

            builder.OwnsOne(product => product.Amount, productAmount =>
            {
                productAmount.Property(amount => amount.value).HasColumnName(nameof(Product.Amount))
                    .HasColumnType("money").IsRequired();
            });

            builder.Property(product => product.BillingPeriod).HasColumnName(nameof(Product.BillingPeriod))
                .HasConversion<string>();
        }
    }
}
