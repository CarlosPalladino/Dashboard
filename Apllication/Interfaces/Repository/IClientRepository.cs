using Domain.Entities;

namespace Apllication.Interfaces.Repository
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllClientsAsync();
    }
}
