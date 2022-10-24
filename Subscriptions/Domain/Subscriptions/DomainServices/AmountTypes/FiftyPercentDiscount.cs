namespace Subscriptions.Domain.Subscriptions.DomainServices.AmountTypes
{
    public sealed class FiftyPercentDiscount : IDiscount
    {
        const int OneThousand = 1000;
        const decimal FiftyPercent = 0.5M;

        public bool IsValid(decimal amount) =>
            amount >= OneThousand;

        public decimal Price(decimal money) =>
            money * FiftyPercent;
    }
}
