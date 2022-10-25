using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Subscriptions.Contracts.Commands;
using Subscriptions.Domain.Abstractions.ISubscriptions;
using Subscriptions.Infrastructure;

namespace Subscriptions.Applications.CommandHandlers
{
    public class SubscribeRequestHandler : IRequestHandler<SubscribeRequest>
    {
        private readonly ISubscriptionAmountCalculator subscriptionAmountCalculator;
        private readonly SubscriptionContext subscriptionContext;

        public SubscribeRequestHandler(
            ISubscriptionAmountCalculator subscriptionAmountCalculator,
            SubscriptionContext subscriptionContext)
        {
            this.subscriptionAmountCalculator = subscriptionAmountCalculator;
            this.subscriptionContext = subscriptionContext;
        }

        public async Task<Unit> Handle(SubscribeRequest request, CancellationToken cancellationToken)
        {
            var customer =
                await this.subscriptionContext
                    .Customers
                        .FindAsync(request.CustomerId);

            var product =
                await this.subscriptionContext
                    .Products
                        .FindAsync(request.ProductId);

            customer.AddSubscription(product, this.subscriptionAmountCalculator);

            await this.subscriptionContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
