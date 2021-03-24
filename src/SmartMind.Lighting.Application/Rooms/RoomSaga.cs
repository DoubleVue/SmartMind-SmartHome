using System.Linq;
using System.Threading.Tasks;
using SmartMind.Core.Domain.Model;
using SmartMind.SmartHome.Lighting.Domain.Model.Rooms;

namespace SmartMind.Lighting.Application.Rooms
{
    public class  RoomSaga :
        IInitiatedBy<DefineNewRoomCommand>,
        IHandle<RenameRoomCommand>
    {
        RoomSaga(IRoomRepository repository, IDomainEventPublisher eventPublisher)
        {
            this.repository = repository;
            this.eventPublisher = eventPublisher;
        }

        public  async Task InitiatedByAsync(DefineNewRoomCommand command)
        {
            RoomDefined @event = new
            (
                RoomId.NewId(),
                new RoomTitle(command.Title),
                command.LightDevices.Select(name => new LightDevice(
                    LightDeviceId.NewId(),
                    new LightDeviceTitle(name))).ToList()
            );
            var room = Room.Create(@event);
            
            await repository.SaveAsync(room);
            await eventPublisher.PublishAsync(@event);
        }

        public async Task HandleAsync(RenameRoomCommand command)
        {
            RoomId id = new (command.RoomId) ;
            var room = await  repository.GetAsync(id);
            
            RoomRenamed @event = new
            (
                id,
                new RoomTitle(command.Title)
            );
            
            room.Apply(@event);

            await repository.SaveAsync(room);
            await eventPublisher.PublishAsync(@event);
        }
        
        private readonly IRoomRepository repository;
        private readonly IDomainEventPublisher eventPublisher;
    }
}