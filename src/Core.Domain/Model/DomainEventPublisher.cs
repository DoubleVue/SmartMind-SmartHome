using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMind.Core.Domain.Model
{
    public class DomainEventPublisher : IDomainEventPublisher, ISubscribable
    {
        DomainEventPublisher()
        {
            publishing = false;
        }

        bool publishing;

        private List<IDomainEventSubscriber<IDomainEvent>> Subscribers { get; } = new();

        public async Task PublishAsync<TDomainEvent>(TDomainEvent @event) 
            where TDomainEvent : IDomainEvent
        {
            if (publishing || !HasSubscribers()) return;
            
            try
            {
                publishing = true;

                var eventType = typeof(TDomainEvent);

                foreach (var subscriber in Subscribers)
                {
                    if (eventType != subscriber.SubscribedToEventType()) continue;
                    
                    await subscriber.HandleEventAsync(@event);
                }
            }
            finally
            {
                publishing = false;
            }
        }

        public async Task PublishAllAsync(IEnumerable<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                await PublishAsync(domainEvent);
            }
        }

        public void Reset()
        {
            if (!publishing)
            {
                Subscribers.Clear();
            }
        }

        public void Subscribe(IDomainEventSubscriber<IDomainEvent> subscriber)
        {
            if (!publishing)
            {
                Subscribers.Add(subscriber);
            }
        }

        public void Subscribe(Func<IDomainEvent, Task> handle) =>
            Subscribe(new DomainEventSubscriber<IDomainEvent>(handle));

        private class DomainEventSubscriber<TDomainEvent> : IDomainEventSubscriber<TDomainEvent>
            where TDomainEvent : IDomainEvent
        {
            public DomainEventSubscriber(Func<TDomainEvent, Task> handle) => 
                this.handle = handle;

            public async Task HandleEventAsync(TDomainEvent @event) => await handle(@event);

            public Type SubscribedToEventType() => typeof(TDomainEvent);
            
            readonly Func<TDomainEvent, Task> handle;
        }

        private bool HasSubscribers() => Subscribers.Any();
    }
}
