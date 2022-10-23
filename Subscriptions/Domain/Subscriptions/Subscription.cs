using System;
using Subscriptions.Domain.Customers;
using Subscriptions.Domain.Products;

namespace Subscriptions.Domain.Subscriptions
{
    public sealed class Subscription
    {
        private Subscription()
        { }

        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }

        public SubscriptionStatus SubscriptionStatus { get; private set; }
        public decimal Amount { get; private set; }
        public DateTimeOffset CurrentPeriondEndDate { get; private set; }

        public Subscription(Guid customerId, Guid productId, Customer customer, Product product, decimal amount)
            : this()
        {
            this.CustomerId = customerId;
            this.ProductId = ProductId;
            this.Customer = customer;
            this.Product = product;
            this.Amount = amount;
            this.SubscriptionStatus = SubscriptionStatus.Active;
        }
    }
}
