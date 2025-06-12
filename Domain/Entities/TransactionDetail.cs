public class TransactionDetail
{
    public Guid DetailId { get; private set; }

    public Guid TransactionId { get; private set; }

    public Transaction Transaction { get; private set; }

    public Guid ProductId { get; private set; }

    public Product Product { get; private set; }

    public int Quantity { get; private set; }

    public decimal Amount { get; private set; }

    public int Total { get; private set; }

    protected TransactionDetail() { }

    public TransactionDetail(Guid detailId, Guid transactionId, Guid productId, int quantity, decimal amount, int total)
    {
        DetailId = detailId;
        TransactionId = transactionId;
        ProductId = productId;
        Quantity = quantity;
        Amount = amount;
        Total = total;
    }
}
