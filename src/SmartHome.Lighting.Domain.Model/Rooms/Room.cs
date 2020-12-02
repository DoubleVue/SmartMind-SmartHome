using System;
using System.Collections.Generic;
using System.Linq;
using SmartMind.Core.Domain.Model;

namespace SmartMind.SmartHome.Lighting.Domain.Model.Rooms
{
    public class Room : EventSourcedRootEntity,
        IAggregateRoot, 
        IApplyEvent<RoomDefined>,
        IApplyEvent<RoomRenamed>

    {
        public static Room Create(RoomDefined initEvent) =>
            new Room(new []{initEvent}, 1);

        public Room(IEnumerable<IDomainEvent> eventStream, int streamVersion)
            : base(eventStream, streamVersion)
        {
            if (eventStream.OfType<RoomDefined>().Any() is false)
            {
                throw new ArgumentOutOfRangeException($"No {typeof(RoomDefined)} event was fond!");
            }
        }

        public RoomId Id { get; private set; } = null!;
        public RoomTitle Title { get; private set; } = null!;

        public record RoomTitle(string Value) : ValueObject;

        public void Apply(RoomDefined @event)
        {
            Id = @event.Id;
            Title = @event.Title;
        }

        public void Apply(RoomRenamed @event)
        {
            if (@event.Id != Id) throw new InvalidOperationException("This event does no belong to this entity!");
            
            Title = @event.Title;
        }
    }

    public sealed record RoomId(Guid Value) : ValueObject, IIdentity<Room>
    {
        public static RoomId NewId() => new RoomId(Guid.NewGuid());
    }
}