using Apllication.Records;

namespace Apllication.Interfaces.Services
{
    public interface IClientInterface
    {
        Task<List<ClientRecordInfo>> GetAllClientsAsync();
        Task<IEnumerable<ClientRecordInfo>> GetClientInformation(string name);
        Task<Guid> CreateClientAsync(NewClientRecord newClient);
    }
}
