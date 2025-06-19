using Domain;

public class CreatedEvent : DomainEvent
{
    public Guid ClientId { get; }

    public CreatedEvent(Guid clientId)
    {
        ClientId = clientId;
    }
}
