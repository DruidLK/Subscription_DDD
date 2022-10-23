using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subscriptions.Domain.Customers;
using Subscriptions.Domain.ValueObjects;

namespace Subscriptions.Infrastructure.config
{
    public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));
            builder.HasKey(customer => customer.Id);
            builder.Property(customer => customer.Id).ValueGeneratedOnAdd().IsRequired();

            builder.OwnsOne(customer => customer.Email, customerEmail =>
            {
                customerEmail.Property(email => email.value).HasColumnName(nameof(Email)).HasMaxLength(300).IsRequired();
                customerEmail.HasIndex(email => email.value).IsUnique();
            });

            builder.OwnsOne(customer => customer.CustomerName, customerName =>
            {
                customerName.Property(name => name.FirstName).HasColumnName(nameof(Customer.CustomerName.FirstName)).HasMaxLength(300).IsRequired();
                customerName.Property(name => name.LastName).HasColumnName(nameof(Customer.CustomerName.LastName)).HasMaxLength(300).IsRequired();
            });

            builder.Property(customer => customer.MoneySpent).HasColumnType("money").HasColumnName(nameof(Customer.MoneySpent));
        }
    }
}
