using System;

namespace SmartMind.Core.Domain.Model
{
    public record DomainEventId(Guid Value) : ValueObject
    {
        public static DomainEventId NewId() => new (Guid.NewGuid());
    }
}