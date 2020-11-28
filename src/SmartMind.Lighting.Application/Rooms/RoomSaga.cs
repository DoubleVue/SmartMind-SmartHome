using System.Threading.Tasks;
using SmartMind.Core.Domain.Model;
using SmartMind.SmartHome.Lighting.Domain.Model.Rooms;

namespace SmartMind.Lighting.Application.Rooms
{
    public class  RoomSaga :
        IInitiatedBy<DefineNewRoomCommand>,
        IHandle<RenameRoomCommand>
    {
        RoomSaga(IRoomRepository repository)
        {
            this.repository = repository;
        }

        private readonly IRoomRepository repository;

        public async Task HandleAsync(DefineNewRoomCommand command)
        {
            RoomDefined @event = new
            (
                RoomId.NewId(),
                new Room.RoomTitle(command.Title)
            );
            var room = Room.Create(@event);
            
            await repository.SaveAsync(room);
        }

        public async Task HandleAsync(RenameRoomCommand command)
        {
            var roomId = new RoomId(command.RoomId) ;
            var room = await  repository.GetByAsync(roomId);
            RoomRenamed @event = new
            (
                roomId,
                new Room.RoomTitle(command.Title)
            );
            
            room.Apply(@event);

            await repository.SaveAsync(room);


        }
    }
}