using System;

namespace SmartMind.Core.Domain.Model
{
    public abstract record DomainEvent : IDomainEvent
    {
        public DomainEventId EventId { get; } = DomainEventId.NewId();
        public int EventVersion { get; } = 1;
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }
}