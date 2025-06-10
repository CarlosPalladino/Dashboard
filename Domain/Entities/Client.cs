using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Client
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        [JsonPropertyName("CUIT")]
        public int Cuit { get; private set; }

        public int Adress { get; private set; }

        protected Client() { }

        public Client(Guid id, string name, int cuit, int adress)
        {
            Id = id;
            Name = name;
            Cuit = cuit;
            Adress = adress;
        }
    }
}
