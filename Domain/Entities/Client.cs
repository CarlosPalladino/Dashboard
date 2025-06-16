namespace Domain.Entities
{
    public class Client
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
        }

        public void GetClientByname(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }
            Name = name;
        }



    }
}
