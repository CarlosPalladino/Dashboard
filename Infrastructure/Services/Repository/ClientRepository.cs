using Apllication.Interfaces.Repository;
using Apllication.Records;
using Domain.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            var client = await _context.Clients
                .Where(c => c.Active)
                .ToListAsync();
            return client;
        }

        public async Task<Client?> GetByNameAsync(string name)
        {
            var findClient = await _context.Clients
                            .Where(c => c.Name.Equals(name))
                            .FirstOrDefaultAsync();
            return findClient;
        }

        public async Task<IEnumerable<ClientRecordInfo>> GetClientInformation(string name)
        {
            var clientByName = await _context.Clients
                .Where(c => c.Name.Equals(name) || c.Name.Contains(name))
                .Select(c => new ClientRecordInfo(c.Name, c.Address, c.Active))
                 .ToListAsync();
            return clientByName;
        }
        public async Task<bool> IsActive(string name)
        {
            var isAcive = await _context.Clients
                .Where(c => c.Name.Equals(name))
                .FirstOrDefaultAsync();
            return isAcive?.Active ?? false;
        }

        public async Task UpdateAsync(Client client)
        {
            _context.Update(client);
            await _context.SaveChangesAsync();
        }
    }
}
