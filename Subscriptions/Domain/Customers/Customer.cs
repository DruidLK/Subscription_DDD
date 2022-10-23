namespace Subscriptions.Domain.Customers
{
    public sealed class Customer
    {
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public decimal MoneySpent { get; private set; }

    }
}
