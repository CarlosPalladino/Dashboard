public class Product
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public decimal ReferenceAmount { get; private set; }

    public int Stock { get; private set; }

    public bool Active { get; private set; }

    public ICollection<TransactionDetail> TransactionDetails { get; private set; }

    public ICollection<Product_Provider> ProductProviders { get; private set; }

    protected Product()
    {
        TransactionDetails = new List<TransactionDetail>();
        ProductProviders = new List<Product_Provider>();
    }

    public Product(string name, decimal referenceAmount, int stock, bool active)
    {
        Id = Guid.NewGuid();
        Name = name;
        ReferenceAmount = referenceAmount;
        Stock = stock;
        Active = active;
        TransactionDetails = new List<TransactionDetail>();
        ProductProviders = new List<Product_Provider>();
    }
}
