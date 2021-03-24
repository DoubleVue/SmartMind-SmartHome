using System;
using SmartMind.Core.Domain.Model;

namespace SmartMind.SmartHome.Lighting.Domain.Model.Rooms
{
    public class LightDevice : Entity,
    IApplyEvent<LightSwitchedOn>,
    IApplyEvent<LightSwitchedOff>
    {
        public LightDevice(LightDeviceId id, LightDeviceTitle title)
        {
            Id = id;
            Title = title;
        }

        public LightDeviceId Id { get; }

        public LightDeviceTitle Title { get; }

        public override IIdentity Identity => Id;

        public void Apply(LightSwitchedOn @event)
        {
            throw new NotImplementedException();
        }

        public void Apply(LightSwitchedOff @event)
        {
            throw new NotImplementedException();
        }
    }
    
    public sealed record LightDeviceId(Guid Value) : ValueObject, IIdentity<Room>
    {
        public static LightDeviceId NewId() => new (Guid.NewGuid());
    }

    public sealed record LightDeviceTitle(string Value) : ValueObject;
}