using Domain.Entities;

public class Conciliation
{
    public Guid Id { get; private set; }

    public DateTime StartDate { get; private set; }

    public DateTime EndDate { get; private set; }

    public string UserResponsable { get; private set; }

    public bool Active { get; private set; }

    public ICollection<Transaction> Transactions { get; private set; }

    protected Conciliation()
    {
        Transactions = new List<Transaction>();
    }

    public Conciliation(Guid id, DateTime startDate, DateTime endDate, string userResponsable, bool active)
    {
        Id = id;
        StartDate = startDate;
        EndDate = endDate;
        UserResponsable = userResponsable;
        Active = active;
        Transactions = new List<Transaction>();
    }
}
