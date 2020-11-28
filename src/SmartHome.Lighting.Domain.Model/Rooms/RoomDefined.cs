using System;
using SmartMind.Core.Domain.Model;

namespace SmartMind.SmartHome.Lighting.Domain.Model.Rooms
{
    public sealed record RoomDefined(
        RoomId Id, 
        Room.RoomTitle Title) : IDomainEvent
    {
        public DomainEventId EventId { get; } = DomainEventId.NewId();
        public int EventVersion { get; } = 1;
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }

    public sealed record RoomRenamed(
        RoomId Id,
        Room.RoomTitle Title) : IDomainEvent
    {
        public DomainEventId EventId { get; } = DomainEventId.NewId();
        public int EventVersion { get; } = 1;
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }
}