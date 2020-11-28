namespace SmartMind.Core.Domain.Model
{
    public interface IApplyEvent<in TDomainEvent> 
        where TDomainEvent : IDomainEvent
    {
        void Apply(TDomainEvent @event);
    }
}