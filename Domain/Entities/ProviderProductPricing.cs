namespace Domain.Entities
{
    public class ProviderProductPricing
    {
        public Guid Id { get; private set; }
        public Guid ProviderId { get; private set; }
        public Guid ProductId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime ValidFrom { get; private set; }

        private ProviderProductPricing() { }

        public ProviderProductPricing(Guid id, Guid providerId, Guid productId, decimal amount, DateTime validFrom)
        {
            Id = id;
            ProviderId = providerId;
            ProductId = productId;
            Amount = amount;
            ValidFrom = validFrom;
        }
    }

}