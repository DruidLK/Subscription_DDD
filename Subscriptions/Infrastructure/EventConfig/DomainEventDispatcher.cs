using System.Threading.Tasks;
using System.Threading;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Subscriptions.Domain.Base;
using System.Linq;

namespace Subscriptions.Infrastructure.EventConfig
{
    public sealed class DomainEventDispatcher : SaveChangesInterceptor
    {
        private readonly IMediator mediator;

        public DomainEventDispatcher(IMediator mediator) =>
            this.mediator = mediator;

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
          DbContextEventData eventData,
          InterceptionResult<int> result,
          CancellationToken cancellationToken = new CancellationToken())
        {
            await DispatchDomainEventsAsync(eventData.Context.ChangeTracker);
            return result;
        }
        private async Task DispatchDomainEventsAsync(ChangeTracker changeTracker)
        {
            var domainEntities = changeTracker
                .Entries<Entity>()
                .Select(x => x.Entity)
                .Where(x => x.DomainEvents.Any())
                .ToList();

            foreach (var entity in domainEntities)
            {
                var events = entity.DomainEvents.ToArray();
                entity.ClearDomainEvent();
                foreach (var domainEvent in events)
                {
                    await this.mediator.Publish(domainEvent).ConfigureAwait(false);
                }
            }
        }
    }
}
}
