namespace SmartMind.Core.Domain.Model
{
    public interface IIdentity
    {}

    public interface IIdentity<in TEntity> : IIdentity
        where TEntity : Entity
    {}
}