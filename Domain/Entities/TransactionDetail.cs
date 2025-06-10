using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class TransactionDetail
    {
        public int DetailId { get; private set; }

        [ForeignKey(nameof(TransactionId))]

        public int TransactionId { get; private set; }

        [ForeignKey(nameof(ProductId))]

        public int ProductId { get; private set; }

        public int Count { get; private set; }

        public decimal PriceUnity { get; private set; }

        public int Total { get; private set; }

        protected TransactionDetail() { }


        public TransactionDetail(int detailId, int transactionId, int productId, int count, decimal priceUnity, int total)
        {
            DetailId = detailId;
            TransactionId = transactionId;
            ProductId = productId;
            Count = count;
            PriceUnity = priceUnity;
            Total = total;
        }
    }
}
