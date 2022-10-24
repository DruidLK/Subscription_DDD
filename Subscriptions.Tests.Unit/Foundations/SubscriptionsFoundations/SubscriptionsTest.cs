using Subscriptions.Domain.Subscriptions.DomainServices;

namespace Subscriptions.Tests.Unit.Foundations.SubscriptionsFoundations
{
    public partial class SubscriptionsTest
    {
        private readonly SubscriptionAmountCalculator subscriptionAmountCalculator;

        public SubscriptionsTest() =>
            this.subscriptionAmountCalculator = new SubscriptionAmountCalculator();
    }
}
