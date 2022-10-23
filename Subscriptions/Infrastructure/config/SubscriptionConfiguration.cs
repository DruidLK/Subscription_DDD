using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Subscriptions.Domain.Subscriptions;

namespace Subscriptions.Infrastructure.config
{
    public sealed class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(subscription => new
            {
                subscription.CustomerId,
                subscription.ProductId
            });

            builder.Property(subscription => subscription.Amount).HasColumnName(nameof(Subscription.Amount))
                .HasColumnType("money").IsRequired();

            builder.Property(subscription => subscription.SubscriptionStatus)
                .HasConversion(new EnumToStringConverter<SubscriptionStatus>()).IsRequired();

            builder.Property(subscription => subscription.CurrentPeriondEndDate).IsRequired();

            builder.HasOne(subscription => subscription.Customer)
               .WithMany(customer => customer.Subscriptions)
               .HasForeignKey(subscription => subscription.CustomerId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(subscription => subscription.Product)
                .WithMany(product => product.Subscriptions)
                .HasForeignKey(subscription => subscription.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
