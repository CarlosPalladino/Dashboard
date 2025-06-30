public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal ReferenceAmount { get; private set; }
    public int Stock { get; private set; }
    public bool Active { get; private set; } = true;

    private Product() { }

    public Product(Guid id, string name, decimal referenceAmount, int stock, bool active)
    {
        Id = id;
        Name = name;
        ReferenceAmount = referenceAmount;
        Stock = stock;
        Active = active;
    }

    public static Product NewProduct(Guid id, string name, decimal referenceAmount, int stock, bool active)
    {
        return new Product(id, name, referenceAmount, stock, active);

    }
    public void Desactivate(string name)
    {
        if (!Active) throw new InvalidOperationException("this product is already off");

        Active = false;

    }
    public void Reactivate(string name)
    {
        if (Active) throw new InvalidOperationException("This prodcut is already active");

        Active = true;
    }
    


}
