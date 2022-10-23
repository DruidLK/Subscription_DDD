using System;
using Subscriptions.Domain.Base;
using Subscriptions.Domain.ValueObjects;

namespace Subscriptions.Domain.Products
{
    public sealed class Product : Entity
    {
        private Product()
        { }

        public string Name { get; private set; }
        public Money Amount { get; private set; }
        public BillingPeriod BillingPeriod { get; private set; }

        public Product(string Name, Money Amount, BillingPeriod BillingPeriod)
        {
            Id = Guid.NewGuid();
            this.Name = Name ?? throw new ArgumentNullException(nameof(Name));
            this.Amount = Amount.value >= 0 ? Amount : throw new ArgumentOutOfRangeException(nameof(Amount));
            this.BillingPeriod = BillingPeriod;
        }
    }
}
