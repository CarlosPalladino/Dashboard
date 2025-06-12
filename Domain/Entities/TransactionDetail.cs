public class TransactionDetail
{
    public Guid Id { get; private set; }
    public Guid TransactionId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Amount { get; private set; }
    public decimal Total { get; private set; }

    private TransactionDetail() { } 

    public TransactionDetail(Guid id, Guid transactionId, Guid productId, int quantity, decimal amount, decimal total)
    {
        Id = id;
        TransactionId = transactionId;
        ProductId = productId;
        Quantity = quantity;
        Amount = amount;
        Total = total;
    }
}
