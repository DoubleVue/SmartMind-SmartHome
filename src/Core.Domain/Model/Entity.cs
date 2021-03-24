namespace SmartMind.Core.Domain.Model
{
    public abstract class Entity
    {
        public abstract IIdentity Identity { get; }
    }
}