public class Conciliation
{
    public Guid Id { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string UserResponsable { get; private set; }
    public bool Active { get; private set; }

    private Conciliation() { }

    public Conciliation(Guid id, DateTime startDate, DateTime endDate, string userResponsable, bool active)
    {
        Id = id;
        StartDate = startDate;
        EndDate = endDate;
        UserResponsable = userResponsable;
        Active = active;
    }
}
