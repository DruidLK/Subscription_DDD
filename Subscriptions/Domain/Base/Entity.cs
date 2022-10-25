using System;
using System.Collections.Generic;
using Subscriptions.Domain.Abstractions.IEvents;

namespace Subscriptions.Domain.Base
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        private readonly List<IDomainEvent> domainEvents =
            new List<IDomainEvent>();

        public IReadOnlyCollection<IDomainEvent> DomainEvents =>
            this.domainEvents.AsReadOnly();

        protected void AddDomainEvent(IDomainEvent eventItem) =>
            this.domainEvents.Add(eventItem);

        protected void RemoveDomainEvent(IDomainEvent eventItem) =>
            this.domainEvents?.Remove(eventItem);

        public void ClearDomainEvent() =>
            this.domainEvents?.Clear();

    }
}
