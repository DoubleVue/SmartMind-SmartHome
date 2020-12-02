using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartMind.Core.Domain.Model
{
    public interface IDomainEventPublisher
    {
        Task PublishAsync<TDomainEvent>(TDomainEvent @event) 
            where TDomainEvent : IDomainEvent;

        Task PublishAllAsync(IEnumerable<IDomainEvent> domainEvents);
    }
}