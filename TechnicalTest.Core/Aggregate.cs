namespace TechnicalTest.Core;

public abstract class Aggregate(Guid id)
{
    public Guid Id { get; init; } = id;

    private readonly List<DomainEvent> _domainEvents = new();

    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void RegisterDomainEvent(DomainEvent @event)
    {
        ((dynamic)this).Apply((dynamic)@event);
        _domainEvents.Add(@event);
    }
    public void ClearDomainEvents() => _domainEvents.Clear();
}
