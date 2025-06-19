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
            var client = await _context.Clients.ToListAsync();
            return client;
        }

        public async Task<IEnumerable<ClientRecordInfo>> GetClientInformation(string name)
        {
            var clientByName = await _context.Clients
                .Where(c => c.Name.Equals(name) || c.Name.Contains(name))
                .Select(c => new ClientRecordInfo(c.Name, c.Address))
                 .ToListAsync();
               return clientByName;
        }
    }
}
