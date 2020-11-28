using System;
using SmartMind.Core.Domain.Model;

namespace SmartMind.Lighting.Application.Rooms
{
    public sealed record RenameRoomCommand(Guid RoomId, string Title) : ICommand;
}