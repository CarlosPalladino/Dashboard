public class Product_Provider
{
    public Guid ProductId { get; private set; }

    public Product Product { get; private set; } = default!;

    public Provider Provider { get; private set; } = default!;

    public Guid ProviderId { get; private set; }

    public decimal Amount { get; private set; }

    public DateTime Delivery { get; private set; }

    protected Product_Provider() { }

    public Product_Provider(Guid productId, Guid providerId, decimal amount, DateTime entrega)
    {
        ProductId = productId;
        ProviderId = providerId;
        Amount = amount;
        Delivery = entrega;
    }
}
