namespace TestApp.Core.Domain
{
    public interface IEntity<out TIdentifier>
    {
        TIdentifier Id { get; }
    }
}
