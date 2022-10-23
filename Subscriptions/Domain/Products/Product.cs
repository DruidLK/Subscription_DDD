namespace Subscriptions.Domain.Products
{
    public sealed class Product
    {
        public string Name { get; private set; }
        public decimal Amount { get; private set; }
        public BillingPeriod BillingPeriod { get; private set; }
    }
}
