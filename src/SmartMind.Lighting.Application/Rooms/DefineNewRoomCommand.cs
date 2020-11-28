using SmartMind.Core.Domain.Model;

namespace SmartMind.Lighting.Application.Rooms
{
    public sealed record DefineNewRoomCommand(string Title) : ICommand;
}