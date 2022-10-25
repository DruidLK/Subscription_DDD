using System.Threading.Tasks;
using Subscriptions.Domain.Abstractions.IEmailNotifications;

namespace Subscriptions.Infrastructure.EmailConfig
{
    public sealed class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(EmailNotification emailNotification) =>
            await Task.CompletedTask;
    }
}
