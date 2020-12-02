using System;
using System.Threading.Tasks;

namespace SmartMind.Core.Domain.Model
{
    public interface ISubscribable
    {
        void Subscribe(IDomainEventSubscriber<IDomainEvent> subscriber);
        void Subscribe(Func<IDomainEvent, Task> handle);
    }
}