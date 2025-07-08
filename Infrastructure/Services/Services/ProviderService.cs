using Apllication.Interfaces.Repository;
using Apllication.Interfaces.Services;
using Apllication.Validations;
using static Apllication.Records.ProviderRecord;

namespace Infrastructure.Services.Services
{
    public class ProviderService : IProviderInterface
    {
        private readonly IProviderRepository _service;

        public ProviderService(IProviderRepository service)
        {
            _service = service;
        }

        public Task DeleteProvider(string email)
        {
            return _service.DeleteProvider(email);
        }

        public async Task<ProviderInformation> ProviderInformation(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BadHttpRequestException("El nombre no puede estar vacío.");
            var provider = await _service.GetProviderInformation(name);
            if (provider is null)
                throw new NotFoundException($"there is no provider with name: {name}");

            return new ProviderInformation(provider.Name, provider.Email);
        }

        public async Task<List<ProviderInformation>> ProviderList()
        {
            var providerList = await _service.GetProvidersListAsync();

            return providerList.Select(pr => new ProviderInformation(pr.Name, pr.Email))
                               .ToList();
        }
    }
}
