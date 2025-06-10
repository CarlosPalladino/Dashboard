namespace Domain.Entities
{
    public class TransactionDetail
    {
        public int DetailId { get; private set; }

        public int TransactionId { get; private set; }

        public int ProductId { get; private set; }

        public int Quantity { get; private set; }

        public decimal Amount { get; private set; }

        public int Total { get; private set; }

        protected TransactionDetail() { }


        public TransactionDetail(int detailId, int transactionId, int productId, int count, int priceUnity, int total)
        {
            DetailId = detailId;
            TransactionId = transactionId;
            ProductId = productId;
            Amount = count;
            Quantity = priceUnity;
            Total = total;
        }
    }
}
