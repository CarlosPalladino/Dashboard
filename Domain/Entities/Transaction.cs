using Domain.Entities;
using Domain.Enums;

public class Transaction
{
    public Guid Id { get; private set; }

    public DateTime Date { get; private set; }

    public TransactionType TransactionType { get; private set; } // Enum específico

    public Guid ClientId { get; private set; }

    public Client Client { get; private set; }

    public Guid ProviderId { get; private set; }

    public Provider Provider { get; private set; }

    public Guid ConciliacionId { get; private set; }

    public Conciliation Conciliation { get; private set; }

    public string Observation { get; private set; }

    public ICollection<TransactionDetail> Details { get; private set; }

    protected Transaction()
    {
        Details = new List<TransactionDetail>();
    }

    public Transaction(Guid id, DateTime date, Guid clientId, Guid providerId, Guid conciliacionId, string observation, TransactionType enumType)
    {
        Id = id;
        Date = date;
        ClientId = clientId;
        ProviderId = providerId;
        ConciliacionId = conciliacionId;
        Observation = observation;
        TransactionType = enumType;
        Details = new List<TransactionDetail>();
    }
}
