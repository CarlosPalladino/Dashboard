namespace Domain.Entities
{
    public class Client
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public long Cuit { get; private set; }

        public string Adress { get; private set; }
        public ICollection<Transaction> Transactions { get; private set; }

        protected Client()
        {
            Transactions = new List<Transaction>();

        }

        public Client(Guid id, string name, long cuit, string adress)
        {
            Id = id;
            Name = name;
            Cuit = cuit;
            Adress = adress;
            Transactions = new List<Transaction>();

        }
    }
}
