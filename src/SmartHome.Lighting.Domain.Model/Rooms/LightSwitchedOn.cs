using SmartMind.Core.Domain.Model;

namespace SmartMind.SmartHome.Lighting.Domain.Model.Rooms
{
    public sealed record LightSwitchedOn
    (
        RoomId Id,
        LightDeviceId LightDeviceId
    ) : DomainEvent;
}