namespace Subscriptions.Infrastructure.EmailConfig
{
    public sealed record EmailNotification
        (
            string From,
            string To,
            string Subject
        );
}
