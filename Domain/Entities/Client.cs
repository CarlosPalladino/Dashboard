namespace Domain.Entities
{
    public class Client
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public long Cuit { get; private set; }
        public string Address { get; private set; }

        private Client() { } // Para Entity Framework

        public Client(Guid id, string name, long cuit, string address)
        {
            Id = id;
            Name = name;
            Cuit = cuit;
            Address = address;
        }

    }
}
