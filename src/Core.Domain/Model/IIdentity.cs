namespace SmartMind.Core.Domain.Model
{
    public interface IIdentity<in TEntity> 
        where TEntity : Entity
    {}
}