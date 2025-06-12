namespace Domain.Entities
{
    public class ConciliationTransaction
    {
        public Guid Id { get; private set; }
        public Guid ConciliationId { get; private set; }
        public Guid TransactionId { get; private set; }

        private ConciliationTransaction() { }

        public ConciliationTransaction(Guid id, Guid conciliationId, Guid transactionId)
        {
            Id = id;
            ConciliationId = conciliationId;
            TransactionId = transactionId;
        }
    }

}
