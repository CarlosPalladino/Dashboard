public class Provider
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public long Cuit { get; private set; }

    public string Email { get; private set; }

    public ICollection<Transaction> Transactions { get; private set; }

    public ICollection<Product_Provider> ProductProviders { get; private set; }

    protected Provider()
    {
        Transactions = new List<Transaction>();
        ProductProviders = new List<Product_Provider>();
    }

    public Provider(Guid id, string name, long cuit, string email)
    {
        Id = id;
        Name = name;
        Cuit = cuit;
        Email = email;
        Transactions = new List<Transaction>();
        ProductProviders = new List<Product_Provider>();
    }
}
