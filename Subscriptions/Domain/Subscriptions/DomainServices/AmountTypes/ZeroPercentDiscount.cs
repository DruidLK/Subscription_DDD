namespace Subscriptions.Domain.Subscriptions.DomainServices.AmountTypes
{
    public sealed class ZeroPercentDiscount : IDiscount
    {
        const int OneHundred = 100;
        public bool IsValid(decimal amount) =>
            amount < OneHundred;

        public decimal Price(decimal money) =>
            money;
    }
}
