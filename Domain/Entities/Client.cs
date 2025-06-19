namespace Domain.Entities
{
    public class Client : Entity<Guid>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public long Cuit { get; private set; }
        public string Address { get; private set; }

        private Client() { }

        public Client(Guid id, string name, long cuit, string address)
        {
            Id = id;
            Name = name;
            Cuit = cuit;
            Address = address;
            AddDomainEvent(new CreatedEvent(Id));
        }

        public static Client Create(Guid id, string name, long cuit, string address)
        {
            return new Client(id, name, cuit, address);
        }

        public static Client Update(string name, string address)
        {
            return Client.Update(name, address);
        }

    }
}
