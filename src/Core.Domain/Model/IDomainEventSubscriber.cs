using System;
using System.Threading.Tasks;

namespace SmartMind.Core.Domain.Model
{
    public interface IDomainEventSubscriber<in TDomainEvent> 
        where TDomainEvent : IDomainEvent
    {
        Task HandleEventAsync(TDomainEvent @event);
        Type SubscribedToEventType();
    }
}