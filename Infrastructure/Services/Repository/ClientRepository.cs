using Apllication.Interfaces.Repository;
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

        public Task<List<Client>> GetAllClientsAsync()
        {
            var client = _context.Clients.ToListAsync();
            return client;
        }
    }
}
