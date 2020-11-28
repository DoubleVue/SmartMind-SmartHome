using System.Threading.Tasks;
using SmartMind.Core.Domain.Model;

namespace SmartMind.SmartHome.Lighting.Domain.Model.Rooms
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<Room> GetByAsync(RoomId id);
        Task SaveAsync(Room room);
    }
}