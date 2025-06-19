using Apllication.Records;

namespace Apllication.Interfaces.Services
{
    public interface IClientInterface
    {
        Task<List<ClientRecordInfo>> GetAllClientsAsync();

        Task<Guid> CreateClientAsync(NewClientRecord newClient);
        Task<ClientRecordInfo> GetClientByNameAsync(string name);
    }
}
