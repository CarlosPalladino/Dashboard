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

        public Task<List<Client>> GetAllClientsAsync()
        {
            var client = _context.Clients.ToListAsync();
            return client;
        }
    }
}
