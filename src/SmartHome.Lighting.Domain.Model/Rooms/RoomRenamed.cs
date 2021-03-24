using SmartMind.Core.Domain.Model;

namespace SmartMind.SmartHome.Lighting.Domain.Model.Rooms
{
    public sealed record RoomRenamed
    (
        RoomId Id,
        RoomTitle Title
    ) : DomainEvent;
}