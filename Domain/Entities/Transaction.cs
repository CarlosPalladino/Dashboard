public class Transaction
{
    public Guid Id { get; private set; }
    public DateTime Date { get; private set; }
    public Guid? ClientId { get; private set; }
    public Guid? ProviderId { get; private set; }
    public string Observation { get; private set; }

    private Transaction() { }

    public Transaction(Guid id, DateTime date, Guid? clientId, Guid? providerId, string observation)
    {
        Id = id;
        Date = date;
        ClientId = clientId;
        ProviderId = providerId;
        Observation = observation;
    }
}

