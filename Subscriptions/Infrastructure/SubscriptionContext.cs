using Microsoft.EntityFrameworkCore;
using Subscriptions.Domain.Customers;

namespace Subscriptions.Infrastructure
{
    public sealed class SubscriptionContext : DbContext
    {
        public SubscriptionContext(DbContextOptions<SubscriptionContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SubscriptionContext).Assembly);
        public DbSet<Customer> Customers { get; set; }
    }
}
