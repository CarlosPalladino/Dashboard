using Apllication.Interfaces.Repository;
using Apllication.Interfaces.Services;
using Apllication.Records;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class ClientService : IClientInterface
    {
        private readonly IClientRepository _repo;

        public ClientService(IClientRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> CreateClientAsync(NewClientRecord newclient)
        {
            var id = Guid.NewGuid();
            var client = Client.Create(id, newclient.name, newclient.cuit, newclient.address, newclient.active);
            await _repo.AddAsync(client);
            return client.Id;
        }

        public async Task ChangeClientState(string name)
        {
            var client = await _repo.GetByNameAsync(name);

            if (client.Active)
                client.Desactivate();
            //else
            //    client.ReActivate();

            await _repo.UpdateAsync(client);
        }

        public async Task<List<ClientRecordInfo>> GetAllClientsAsync()
        {
            var client = await _repo.GetAllClientsAsync();

            if (client is null)

                throw new Exception($"there are no clients registered yet");
            return client.Select(c => new ClientRecordInfo(c.Name, c.Address, c.Active)).ToList();

        }
        public async Task<IEnumerable<ClientRecordInfo>> GetClientInformation(string name)
        {
            var clientByName = await _repo.GetClientInformation(name);
            return clientByName;
        }
    }
}
