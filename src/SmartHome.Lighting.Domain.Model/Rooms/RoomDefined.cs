using System.Collections.Generic;
using SmartMind.Core.Domain.Model;

namespace SmartMind.SmartHome.Lighting.Domain.Model.Rooms
{
    public sealed record RoomDefined
    (
        RoomId Id,
        RoomTitle Title,
        IEnumerable<LightDevice> LightDevices
    ) : DomainEvent;
}