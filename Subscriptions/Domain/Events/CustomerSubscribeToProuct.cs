using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Subscriptions.Domain.Abstractions.IEvents;

namespace Subscriptions.Domain.Events
{
    public sealed record CustomerSubscribeToProduct(Guid customerId, Guid productId) : IDomainEvent;

    public sealed class CustomerSubscribedToPoductHandler : INotificationHandler<CustomerSubscribeToProduct>
    {
        //inject email service
        public Task Handle(CustomerSubscribeToProduct notification, CancellationToken cancellationToken)
        {
            //send email async
            return Task.CompletedTask;
        }
    }
}
