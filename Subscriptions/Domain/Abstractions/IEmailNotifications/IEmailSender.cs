using System.Threading.Tasks;
using Subscriptions.Infrastructure.EmailConfig;

namespace Subscriptions.Domain.Abstractions.IEmailNotifications
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailNotification emailNotification);
    }
}
