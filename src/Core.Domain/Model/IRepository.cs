namespace SmartMind.Core.Domain.Model
{
    public interface IRepository<in TEntity> where TEntity : Entity, IAggregateRoot
    {
        
    }
}