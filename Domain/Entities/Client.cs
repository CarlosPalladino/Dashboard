namespace Domain.Entities
{
    public class Client : Entity<Guid>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public long Cuit { get; private set; }
        public string Address { get; private set; }
        public bool Active { get; private set; } = true;

        private Client() { }

        public Client(Guid id, string name, long cuit, string address, bool active)
        {
            Id = id;
            Name = name;
            Cuit = cuit;
            Address = address;
            Active = active;
            AddDomainEvent(new CreatedEvent(Id));
        }

        public static Client Create(Guid id, string name, long cuit, string address, bool active)
        {
            return new Client(id, name, cuit, address, active);
        }

        public void Desactivate()
        {
            if (!Active)
                throw new InvalidOperationException("the client is already inactive");
            Active = false;
        }

        public void ReActivate()
        {
            if (Active)
                throw new InvalidOperationException("the client is already active");

            Active = true;
        }


    }

}
