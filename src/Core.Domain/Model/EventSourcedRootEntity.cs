using System.Collections.Generic;

namespace SmartMind.Core.Domain.Model
{
    public abstract class EventSourcedRootEntity : Entity, IAggregateRoot 
    {
        protected EventSourcedRootEntity(IEnumerable<IDomainEvent> eventStream, int streamVersion)
            : this()
        {
            foreach (var @event in eventStream)
            {
                When(@event);
            }
            unmutatedVersion = streamVersion;
        }

        private EventSourcedRootEntity()
        {
            mutatingEvents = new List<IDomainEvent>();
        }

        public IList<IDomainEvent> GetMutatingEvents() => mutatingEvents.ToArray();
        
        protected int MutatedVersion => unmutatedVersion + 1;
        protected int UnmutatedVersion => unmutatedVersion;

        private void When<TDomainEvent>(TDomainEvent @event)
            where TDomainEvent : IDomainEvent
        {
            (this as dynamic).Apply(@event);
        }

        private readonly List<IDomainEvent> mutatingEvents;
        private readonly int unmutatedVersion;
    }
}