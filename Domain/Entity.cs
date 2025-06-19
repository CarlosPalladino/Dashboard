using Domain;

public abstract class Entity<TId>
{
    public TId Id { get; protected set; }

    private List<DomainEvent> _domainEvents = new();
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(DomainEvent eventItem)
    {
        _domainEvents.Add(eventItem);
    }

    public void ClearDomainEvents() => _domainEvents.Clear();


}


