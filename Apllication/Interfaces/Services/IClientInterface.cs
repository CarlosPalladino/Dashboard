using Apllication.Records;

namespace Apllication.Interfaces.Services
{
    public interface IClientInterface
    {
        Task<List<ClientRecordInfo>> GetAllClientsAsync();

        Task<ClientRecordInfo> GetClientByNameAsync(string name);
    }
}
