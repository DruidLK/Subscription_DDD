using Subscriptions.Domain.Abstractions.ISubscriptions;
using Subscriptions.Domain.Base;
using Subscriptions.Domain.Customers;
using Subscriptions.Domain.Products;

namespace Subscriptions.Domain.Subscriptions.DomainServices
{
    public sealed class SubscriptionAmountCalculator : ISubscriptionAmountCalculator
    {
        public decimal Calculate(Customer customer, Product product)
        {
            var amount = Factory.Get<IDiscount>(x => x.IsValid(customer.MoneySpent));

            var subscriptionAmount = amount.Price(product.Amount.value);

            return subscriptionAmount;
        }
    }
}
