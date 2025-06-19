public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal ReferenceAmount { get; private set; }
    public int Stock { get; private set; }
    public bool Active { get; private set; }

    private Product() { }

    public Product(Guid id, string name, decimal referenceAmount, int stock, bool active)
    {
        Id = id;
        Name = name;
        ReferenceAmount = referenceAmount;
        Stock = stock;
        Active = active;
    }

}
