namespace Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; private set; }

        public DateTime Date { get; private set; }

        public Enum EnumType { get; private set; }

        public int ClientId { get; private set; }

        public int ProviderId { get; private set; }

        public int ConciliacionId { get; private set; }

        public string Observation { get; private set; }



        protected Transaction() { }



        public Transaction(Guid id, DateTime date, int clientId, int providerId, int conciliacionId, string observation, Enum enumType)
        {
            Id = id;
            Date = date;
            ClientId = clientId;
            ProviderId = providerId;
            ConciliacionId = conciliacionId;
            Observation = observation;
            EnumType = enumType;
        }
    }
}