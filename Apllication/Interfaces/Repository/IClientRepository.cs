using Apllication.Records;
using Domain.Entities;

namespace Apllication.Interfaces.Repository
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllClientsAsync();
        Task<IEnumerable<ClientRecordInfo>> GetClientInformation(string name);
        Task UpdateAsync(Client client);
        Task<Client?> GetByNameAsync(string name);
        Task<bool> IsActive(string name);
        Task AddAsync(Client client);
    }
}
