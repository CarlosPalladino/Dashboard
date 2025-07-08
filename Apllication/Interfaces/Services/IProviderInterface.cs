using static Apllication.Records.ProviderRecord;

namespace Apllication.Interfaces.Services
{
    public interface IProviderInterface
    {
        public Task<List<ProviderInformation>> ProviderList();

        public Task<ProviderInformation> ProviderInformation(string name);

        public Task DeleteProvider(string email);
    }
}
