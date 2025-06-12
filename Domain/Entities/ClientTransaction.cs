namespace Domain.Entities
{
    public class ClientTransaction
    {
        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public DateTime Date { get; private set; }
        public string Observation { get; private set; }

        private ClientTransaction() { } 

        public ClientTransaction(Guid id, Guid clientId, DateTime date, string observation)
        {
            Id = id;
            ClientId = clientId;
            Date = date;
            Observation = observation;
        }
    }

}
