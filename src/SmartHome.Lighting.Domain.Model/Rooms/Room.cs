using System;
using System.Collections.Generic;
using System.Linq;
using SmartMind.Core.Domain.Model;

namespace SmartMind.SmartHome.Lighting.Domain.Model.Rooms
{
    public class Room : EventSourcedRootEntity,
        IApplyEvent<RoomDefined>,
        IApplyEvent<RoomRenamed>,
        IApplyEvent<LightSwitchedOn>,
        IApplyEvent<LightSwitchedOff>
    {
        public static Room Create(RoomDefined initEvent) => new(new[] {initEvent}, 1);

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
        public IEnumerable<LightDevice> LightDevices { get; private set; } = null!;

        public override IIdentity Identity => Id;
        
        public void Apply(RoomDefined @event)
        {
            Id = @event.Id;
            Title = @event.Title;
            LightDevices = @event.LightDevices.ToList();
        }

        public void Apply(RoomRenamed @event)
        {
            ValidateAggregateRootId(@event.Id);
            Title = @event.Title;
        }

        public void Apply(LightSwitchedOn @event)
        {
            ValidateAggregateRootId(@event.Id);

            var lightDevice = LightDevices.First(device => device.Id == @event.LightDeviceId);
            lightDevice.Apply(@event);
        }

        public void Apply(LightSwitchedOff @event)
        {
            var lightDevice = LightDevices.First(device => device.Id == @event.LightDeviceId);
            lightDevice.Apply(@event);
        }

        private void ValidateAggregateRootId(RoomId roomId)
        {
            if (roomId != Id) throw new InvalidOperationException("This event does no belong to this entity!");
        }
    }

    public sealed record RoomId(Guid Value) : ValueObject, IIdentity<Room>
    {
        public static RoomId NewId() => new (Guid.NewGuid());
    }

    public sealed record RoomTitle(string Value) : ValueObject;
}