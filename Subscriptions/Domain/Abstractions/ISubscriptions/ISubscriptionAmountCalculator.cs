using Subscriptions.Domain.Customers;
using Subscriptions.Domain.Products;

namespace Subscriptions.Domain.Abstractions.ISubscriptions
{
    public interface ISubscriptionAmountCalculator
    {
        decimal Calculate(Customer customer, Product product);
    }
}
