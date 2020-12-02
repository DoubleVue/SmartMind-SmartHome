using System.Threading.Tasks;

namespace SmartMind.Core.Domain.Model
{
    public interface IHandle<in TCommand>
        where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }

    public interface IInitiatedBy<in TCommand>
        where TCommand : ICommand
    {
        Task InitiatedByAsync(TCommand command);
    }
}