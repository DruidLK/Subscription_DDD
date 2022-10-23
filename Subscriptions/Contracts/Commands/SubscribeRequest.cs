using System;

namespace Subscriptions.Contracts.Commands
{
    public sealed record SubscribeRequest
        (
            Guid CustomerId,
            Guid ProductId
        );
}
