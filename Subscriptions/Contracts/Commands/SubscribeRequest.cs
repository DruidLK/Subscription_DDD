using System;
using MediatR;

namespace Subscriptions.Contracts.Commands
{
    public sealed record SubscribeRequest(Guid CustomerId,Guid ProductId): IRequest;
}
