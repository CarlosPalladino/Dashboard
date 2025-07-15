using Apllication.Interfaces.Repository;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Repository
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly ApplicationDbContext _context;

        public ProviderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task DeleteProvider(string name)
        {
            var provider = await _context.Providers
                .FirstOrDefaultAsync(p => p.Name.Equals(name));

            if (provider is not null)
            {
                _context.Providers.Remove(provider);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Provider?> GetProviderInformation(string name)
        {
            var clientInformation = await _context.Providers
                        .FirstOrDefaultAsync(pr => pr.Name.Equals(name)
                        ||
                        pr.Name.Contains(name));
            return clientInformation;
        }
        public async Task<List<Provider>> GetProvidersListAsync()
        {
            var providerList = await _context.Providers.ToListAsync();
            return providerList;
        }
    }
}
