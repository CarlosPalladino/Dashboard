namespace Domain.Entities
{
    public class Provider
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public int Cuit { get; private set; }

        public string Email { get; private set; }


        protected Provider() { }


        public Provider(Guid id, string name, int cuit, string email)
        {
            Id = id;
            Name = name;
            Cuit = cuit;
            Email = email;

        }
    }
}
