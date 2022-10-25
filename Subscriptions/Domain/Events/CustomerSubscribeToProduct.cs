using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Subscriptions.Domain.Abstractions.IEmailNotifications;
using Subscriptions.Domain.Abstractions.IEvents;
using Subscriptions.Infrastructure.EmailConfig;

namespace Subscriptions.Domain.Events
{
    public sealed record CustomerSubscribeToProduct(Guid customerId, Guid productId) : IDomainEvent;

    public sealed class CustomerSubscribedToPoductHandler : INotificationHandler<CustomerSubscribeToProduct>
    {
        private readonly IEmailSender emailSender;

        public CustomerSubscribedToPoductHandler(IEmailSender emailSender) =>
            this.emailSender = emailSender;

        public async Task Handle(CustomerSubscribeToProduct notification, CancellationToken cancellationToken)
        {
            //retrieve customer name 

            var emailNotification =
                new EmailNotification("Application", "Customer", "Thank you for subscribing");

            await this.emailSender.SendEmailAsync(emailNotification);
        }
    }
}
