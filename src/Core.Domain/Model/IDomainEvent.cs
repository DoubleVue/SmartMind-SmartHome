using System;

namespace SmartMind.Core.Domain.Model
{
    public interface IDomainEvent
    {
        DomainEventId EventId { get; }
        int EventVersion { get; }
        DateTime OccurredOn { get; }
        
        // add user
    }
}