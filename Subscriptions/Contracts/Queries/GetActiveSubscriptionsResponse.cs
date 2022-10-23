namespace Subscriptions.Contracts.Queries
{

    //get active subscriptions response of a specific customer
    public sealed record GetActiveSubscriptionsResponse
        (
            string ProductName,
            string BillingPeriod
        );
}
