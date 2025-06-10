namespace Domain.Entities
{
    public class Product_Provider
    {
        public int ProductId { get; private set; }

        public int ProvedirId { get; private set; }

        public decimal Amount { get; private set; }

        public DateTime Entrega { get; private set; }

        protected Product_Provider() { }


    }
}
