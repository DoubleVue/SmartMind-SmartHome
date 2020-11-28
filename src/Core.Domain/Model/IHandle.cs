using System.Threading.Tasks;

namespace SmartMind.Core.Domain.Model
{
    public interface IHandle<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
    
    public interface IInitiatedBy<in TCommand> : IHandle<TCommand> where TCommand : ICommand
    {}
}