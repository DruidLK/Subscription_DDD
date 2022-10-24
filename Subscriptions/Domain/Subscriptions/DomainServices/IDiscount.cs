namespace Subscriptions.Domain.Subscriptions.DomainServices
{
    public interface IDiscount
    {
        bool IsValid(decimal amount);

        decimal Price(decimal money);
    }
}
