namespace Apllication.Interfaces.Repository
{
    public interface IProviderRepository
    {
        Task<List<Provider>> GetProvidersListAsync();

        Task<Provider> GetProviderInformation(string name);

        Task DeleteProvider(string email);

    }
}
