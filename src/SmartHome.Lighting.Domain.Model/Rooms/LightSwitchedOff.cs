using SmartMind.Core.Domain.Model;

namespace SmartMind.SmartHome.Lighting.Domain.Model.Rooms
{
    public sealed record LightSwitchedOff
    (
        RoomId Id,
        LightDeviceId LightDeviceId
    ) : DomainEvent;
}