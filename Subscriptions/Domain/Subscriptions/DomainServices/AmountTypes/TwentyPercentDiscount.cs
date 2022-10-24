namespace Subscriptions.Domain.Subscriptions.DomainServices.AmountTypes
{
    public sealed class TwentyPercentDiscount : IDiscount
    {
        const int OneHundred = 100;
        const int Thousand = 1000;

        const decimal EightyPercent = 0.8M;
        public bool IsValid(decimal amount) =>
            amount is >= OneHundred and < Thousand;

        public decimal Price(decimal money) =>
            money * EightyPercent;
    }
}
