namespace Subscriptions.Domain.Subscriptions.DomainServices.AmountTypes
{
    public sealed class TwentyPercentDiscount : IDiscount
    {
        const int OneHundred = 100;
        const decimal EightyPercent = 0.8M;
        public bool IsValid(decimal amount) =>
            amount is OneHundred or < 1000;

        public decimal Price(decimal money) =>
            money * EightyPercent;
    }
}
